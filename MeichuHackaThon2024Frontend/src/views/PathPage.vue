<script setup lang="ts">
import SideInfo from "../components/PathPage/SideInfo.vue";
import BottomInfo from "../components/PathPage/BottomInfo.vue";
import LoadingDialog from "../components/LoadingDialog.vue";
import PopUpDoalog from "../components/PathPage/PopUpDoalog.vue";
import { getPathDetailList } from '../api';
import type { GetPathDetailListPayload } from '../api';
import type { Path, PathDetail } from '../type';
import { generateMap } from '../common/generateMap'

const route = useRoute();
const router = useRouter();
const popuptitle = ref('');
const mapId = ref<number>(0);
const data = reactive<Path>({
  id: 0,
  destination: '-',
  location: '-',
  costTime: '-',
  arrivalTime: '-',
  transportComp: {
    '公車': 0,
    'Bike': 0,
    '步行': 0
  },
  crowding: 0,
  path_details: [] as PathDetail[],
});

const mapRef = ref<HTMLElement | null>(null);
const completedSteps = ref<number>(0);
const totalSteps = ref<number>(0);
const LoadingDialogVisable = ref<boolean>(false);
const PopUpDoalogVisable = ref<boolean>(false);

const steps = (action: 'next' | 'pervious') => {
  if (action === 'next') {
    if (completedSteps.value === totalSteps.value) {
      return;
    }

    completedSteps.value++;

    const { destination, location } = data.path_details[completedSteps.value];

    const locs = [
      {
        lng: location.gps.lng,
        lat: location.gps.lat
      },
      {
        lng: destination.gps.lng,
        lat: destination.gps.lat
      }
    ]

    const timestampDiv = document.createElement("div");
    const oldMap = document.getElementById(`map${mapId.value}`);
    if (oldMap) {
      oldMap.remove();
    }
    mapId.value = Date.now();
    timestampDiv.id = `map` + mapId.value.toString();
    mapRef.value?.appendChild(timestampDiv);
    document.getElementById(timestampDiv.id)!.style.height = "100dvh";
    document.getElementById(timestampDiv.id)!.style.width = "100dvw";

    generateMap(locs, timestampDiv.id);

    if (completedSteps.value === totalSteps.value) {
      handlePopUpDialog('抵達');
    }
  }

  if (action === 'pervious') {
    if (completedSteps.value === 0) {
      return;
    }

    completedSteps.value--;

    const { destination, location } = data.path_details[completedSteps.value];

    const locs = [
      {
        lng: location.gps.lng,
        lat: location.gps.lat
      },
      {
        lng: destination.gps.lng,
        lat: destination.gps.lat
      }
    ]

    const timestampDiv = document.createElement("div");
    const oldMap = document.getElementById(`map${mapId.value}`);
    if (oldMap) {
      oldMap.remove();
    }
    mapId.value = Date.now();
    timestampDiv.id = `map` + mapId.value.toString();
    mapRef.value?.appendChild(timestampDiv);
    document.getElementById(timestampDiv.id)!.style.height = "100dvh";
    document.getElementById(timestampDiv.id)!.style.width = "100dvw";

    generateMap(locs, timestampDiv.id);
  }
}

const handlePopUpDialog = (title: string) => {
  popuptitle.value = title;
  PopUpDoalogVisable.value = true;
}

watch(() => completedSteps.value, (step: number) => {
  router.replace({
    query: {
      ...router.currentRoute.value.query,
      step: String(step),
    },
  });

  if (step === totalSteps.value) {
    handlePopUpDialog('抵達');
  }
})

// import * as Leaflet from "leaflet";
// import "leaflet-routing-machine";

// let map: Leaflet.Map;
// // 直接在地圖的dom創建按鈕
// function createButton(label: string, container: HTMLElement) {
//   const btn = Leaflet.DomUtil.create("button", "", container);
//   btn.setAttribute("type", "button");
//   btn.innerHTML = label;
//   btn.classList.add("bg-cyan-200/50", "rounded-full", "p-2");
//   return btn;
// }

// const generateMap = (locs: {
//   lng: string,
//   lat: string
// }[], id: string) => {
//   const totalLng = locs.reduce((a, b) => a + Number(b.lng), 0);
//   const totalLat = locs.reduce((a, b) => a + Number(b.lat), 0);
//   // 初始化地圖
//   map = Leaflet.map(id, {
//     center: [totalLng / locs.length, totalLat / locs.length],
//     zoom: 80,
//   });

//   // todo point myself
//   console.log(map.locate());

//   // 監聽地圖事件
//   map.on("click", function (e) {
//     const container = Leaflet.DomUtil.create("div"),
//       startBtn = createButton("Start from this location", container),
//       destBtn = createButton("Go to this location", container);

//     Leaflet.popup().setContent(container).setLatLng(e.latlng).openOn(map);
//   });
//   // 地圖圖層
//   Leaflet.tileLayer(
//     "https://maps.googleapis.com/maps/vt?pb=!1m5!1m4!1i{z}!2i{x}!3i{y}!4i256!2m3!1e0!2sm!3i349018013!3m9!2sen-US!3sUS!5e18!12m1!1e47!12m3!1e37!2m1!1ssmartmaps!4e0",
//     {
//       attribution: "&copy; Powered by Google",
//       maxZoom: 19,
//     }
//   ).addTo(map);
//   // 增加地圖上標記圖層的元件
//   // const tooltip = Leaflet.marker(
//   //   Leaflet.latLng((Number(des.lng) + Number(loc.lng)) / 2, (Number(des.lat) + Number(loc.lat)) / 2)
//   // ).addTo(map);
//   // 從第一個點開始規劃最短路徑
//   Leaflet.Routing.control({
//     waypoints: [
//       ...locs.map(loc => Leaflet.latLng(Number(loc.lng), Number(loc.lat))),
//     ],
//   })
//     .on("routingstart", function (e) {}) // 也可以監聽事件
//     .addTo(map);
// }


onMounted(async() => {
  LoadingDialogVisable.value = true;
  const { id, step } = route.query;

  // todo 未正確傳遞 query string value 導回首頁
  if(!id) {
    LoadingDialogVisable.value = false;
    handlePopUpDialog('路徑編號錯誤');
    return;
  }

  const payload: GetPathDetailListPayload = {
    id: Number(id),
  }

  const response = await getPathDetailList(payload);

  // todo 錯誤處理
  if (!response.success) {
    return;
  }

  // init
  Object.assign(data, response.data);

  console.log(response.data);

  PopUpDoalogVisable.value = false;
  completedSteps.value = step ? Number(step) : 0;
  totalSteps.value = data.path_details.length;

  LoadingDialogVisable.value = false;

  const { destination, location } = response.data.path_details[completedSteps.value];

  const locs = [
    {
      lng: location.gps.lng,
      lat: location.gps.lat
    },
    {
      lng: destination.gps.lng,
      lat: destination.gps.lat
    }
  ]

  const timestampDiv = document.createElement("div");
  mapId.value = Date.now();
  timestampDiv.id = `map` + mapId.value.toString();
  mapRef.value?.appendChild(timestampDiv);
  document.getElementById(timestampDiv.id)!.style.height = "100dvh";
  document.getElementById(timestampDiv.id)!.style.width = "100dvw";

  generateMap(locs, timestampDiv.id);
})
</script>

<template>
  <div
    class="relative w-full h-full flex flex-col items-center p-4 text-white"
  >
    <div ref="mapRef" class="z-20 absolute w-[100dvw] h-[100dvh] top-0 left-0 flex justify-center items-center bg-gray-900 text-black" />
    <div class="z-20 absolute top-4 text-[1.5rem] font-extrabold text-white bg-gray-800 py-2 px-5 rounded-lg">
      目的地：{{ data.destination }}
    </div>
    <div class="z-20 absolute w-fit h-fit top-24 left-10 flex flex-col px-5 py-4 bg-gray-800 rounded-xl select-none">
      <SideInfo
        :costTime="data.path_details[completedSteps]?.costTime ?? '-'"
        :completedSteps="completedSteps"
        :totalSteps="totalSteps"
        :transport="data.path_details[completedSteps]?.transport ?? {}"
      />
    </div>
    <div class="z-20 absolute bottom-2 mx-6 bg-gray-800 bg-opacity-85 w-5/6 px-6 py-4 rounded-xl select-none">
      <BottomInfo
        :data="data.path_details[completedSteps] ?? {}"
        :hasNextStep="completedSteps < totalSteps - 1"
        :hasPreviousStep="completedSteps > 0"
        @nextStep="steps('next')"
        @previousStep="steps('pervious')"
      />
    </div>
    <LoadingDialog v-if="LoadingDialogVisable" />
    <PopUpDoalog v-if="PopUpDoalogVisable" :title="popuptitle" @close="PopUpDoalogVisable = false" />
  </div>
</template>
