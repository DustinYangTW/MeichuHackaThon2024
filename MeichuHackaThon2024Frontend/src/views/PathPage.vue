<script setup lang="ts">
import SideInfo from "../components/PathPage/SideInfo.vue";
import BottomInfo from "../components/PathPage/BottomInfo.vue";
import LoadingDialog from "../components/PathPage/LoadingDialog.vue";
import PopUpDoalog from "../components/PathPage/PopUpDoalog.vue";
import type { Path } from '../type'

const mockData: Path = {
  id: 1,
  destination: '青青草原',
  location: '國立陽明交通大學體育館',
  costTime: '1h 4m',
  arrivalTime: '09:04',
  transportComp: {
    '公車': 33,
    'Bike': 17,
    '步行': 17
  },
  crowding: 0,
  path_details: [
    {
      destination: {
        gps: '24.791641, 120.997713',
        name: '國立陽明交通大學體育館'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '生科館人社院'
      },
      costTime: '13分',
      arrivalTime: '08:00',
      transport: {
        type: '步行',
        remark: '步行'
      },
      crowding: 2
    },
    {
      destination: {
        gps: '24.791641, 120.997713',
        name: '新竹轉運站'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '生科館人社院'
      },
      costTime: '10分',
      arrivalTime: '08:13',
      transport: {
        type: '公車',
        remark: '83'
      },
      crowding: 4
    },
    {
      destination: {
        gps: '24.791641, 120.997713',
        name: '新竹火車站(中正路)'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '新竹轉運站'
      },
      costTime: '5分',
      arrivalTime: '08:23',
      transport: {
        type: '步行',
        remark: '步行'
      },
      crowding: 1
    },
    {
      destination: {
        gps: '24.791641, 120.997713',
        name: '朝山'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '新竹火車站(中正路)'
      },
      costTime: '20分',
      arrivalTime: '08:28',
      transport: {
        type: '公車',
        remark: '公車編號 5801'
      },
      crowding: 3
    },
    {
      destination: {
        gps: '24.791641, 120.997713',
        name: '香山天后宮'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '朝山'
      },
      costTime: '5分',
      arrivalTime: '08:48',
      transport: {
        type: '步行',
        remark: '步行'
      },
      crowding: 3
    },
    {
      destination: {
        gps: '24.791641, 120.997713',
        name: '青青草原'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '香山天后宮'
      },
      costTime: '16分',
      arrivalTime: '09:04',
      transport: {
        type: 'Bike',
        remark: '香山天后宮站'
      },
      crowding: 1
    }
  ],
};

const route = useRoute();
const router = useRouter();
const popuptitle = ref('');
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
  path_details: [],
});

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

    if (completedSteps.value === totalSteps.value) {
      handlePopUpDialog('抵達');
    }
  }

  if (action === 'pervious') {
    if (completedSteps.value === 0) {
      return;
    }

    completedSteps.value--;
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

onMounted(async() => {
  LoadingDialogVisable.value = true;
  const { id, step } = route.query;

  // todo 未正確傳遞 query string value 導回首頁
  if(!id) {
    LoadingDialogVisable.value = false;
    handlePopUpDialog('路徑編號錯誤');
    return;
  }

  // 模擬 api
  const response: Path = await new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve(mockData);
    }, 1500);
  })

  // init
  Object.assign(data, response);

  console.log(response);

  PopUpDoalogVisable.value = false;
  completedSteps.value = step ? Number(step) : 0;
  totalSteps.value = data.path_details.length;

  LoadingDialogVisable.value = false;
})
</script>

<template>
  <div
    class="relative w-full h-full flex flex-col items-center p-4 text-white"
  >
    <div class="absolute w-[100dvw] h-[100dvh] top-0 left-0 flex justify-center items-center bg-gray-900">
      {map}
    </div>
    <div class="absolute top-4 text-3xl font-extrabold text-white">
      目的地：{{ data.destination }}
    </div>
    <div class="absolute w-fit h-fit top-24 left-10 flex flex-col px-5 py-4 bg-gray-800 rounded-xl select-none">
      <SideInfo
        :costTime="data.path_details[completedSteps]?.costTime ?? '-'"
        :completedSteps="completedSteps"
        :totalSteps="totalSteps"
        :transport="data.path_details[completedSteps]?.transport ?? {}"
      />
    </div>
    <div class="absolute bottom-8 mx-6 bg-gray-800 w-5/6 px-6 py-4 rounded-xl select-none">
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
