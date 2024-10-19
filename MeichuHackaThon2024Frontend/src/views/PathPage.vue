<script setup lang="ts">
import SideInfo from "../components/PathPage/SideInfo.vue";
import BottomInfo from "../components/PathPage/BottomInfo.vue";
import LoadingDialog from "../components/PathPage/LoadingDialog.vue";
import PopUpDoalog from "../components/PathPage/PopUpDoalog.vue";
import { getPathDetailList } from '../api';
import type { GetPathDetailListPayload } from '../api';
import type { Path, PathDetail } from '../type';

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
  path_details: [] as PathDetail[],
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
