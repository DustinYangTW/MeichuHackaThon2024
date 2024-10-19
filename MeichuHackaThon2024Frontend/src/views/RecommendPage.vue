<script setup lang="ts">
import { getRecommendList } from '../api';
import type { GetRecommendListPayload } from '../api';

const router = useRouter();

const selectType = ref<'觀光景點' | '美食' | '廁所' | '公園'>('觀光景點');
const types = ref<string[]>(['觀光景點', '美食', '公園', '廁所']);
const selectDivIndex = ref<number>(-1);
const recommendList = ref<{
  名稱: string;
  地址: string;
  備註: string;
  src: string;
}[]>([]);

const getList = async (type: '觀光景點' | '美食' | '廁所' | '公園') => {
  selectType.value = type;

  const payload: GetRecommendListPayload = {
    type: selectType.value,
  };

  const response = await getRecommendList(payload);

  console.log(response);

  // todo 錯誤處理
  if (!response.success) {
    return;
  }

  recommendList.value = response.data;
  selectDivIndex.value = -1;
}

const gotoPathSelectPage = (location: string) => {
  // todo 要檢查資料庫是否有這個地點
  // true 才轉
  router.push({ name: 'PathSelectPage', query: { q: location } });
}

onMounted(() => {
  getList(selectType.value);
})
</script>

<template>
  <div
    class="w-full h-full bg-gray-900 duration-1000 flex flex-col justify-start items-center pt-12 pl-8 gap-12 select-none relative"
  >
    <button
      class="absolute top-0 left-6 text-xl font-bold py-4 text-white rounded-2xl w-fit flex justify-center items-center hover:text-blue-700 hover:underline"
      @click="router.push({ name: 'home' });"
    >
      < 首頁
    </button>
    <div class="flex gap-5">
      <div
        v-for="type in types" :key="type"
        class="py-4 px-8 rounded-full border-2 border-white text-white cursor-pointer text-2xl font-medium hover:scale-90"
        :class="selectType === type ? 'bg-gray-600 text-white' : ''"
        @click="getList(type)"
      >
        {{ type }}
      </div>
    </div>
    <div class="overflow-x-scroll">
      <div v-if="recommendList.length === 0">
        empty
      </div>
      <div
        v-else
        class="flex flex-wrap justify-center gap-3 relative"
      >
        <div
          v-for="(item, index) in recommendList" :key="`${item}-${index}`"
          class="flex flex-col px-5 py-4 bg-gray-800 rounded-xl bg-cover bg-no-repeat bg-center w-[500px] h-[350px] relative"
          :style="{ backgroundImage: `url(${item.src})` }"
          @mouseenter="selectDivIndex = index"
        >
          <div class="absolute bottom-2 w-[480px] left-1/2 -translate-x-1/2 bg-white rounded-xl text-black px-4 py-3 flex flex-col gap-[1px]">
            <div class="text-xl font-bold flex justify-between">
              <div class="font-black">
                {{ item.名稱 }}
              </div>
              <div class="text-blue-500 cursor-pointer hover:text-blue-800" @click="gotoPathSelectPage(item.名稱)">
                <font-awesome-icon :icon="['fas', 'person-walking-dashed-line-arrow-right']" />
                出發
              </div>
            </div>
            <div class="text-base">
              {{ item.地址 }}
            </div>
            <div
              class="max-h-[50px] text-sm leading-4 text-gray-500"
              :class="[ selectDivIndex === index ? 'overflow-y-auto max-h-[200px]' : 'overflow-hidden overflow-ellipsis whitespace-nowrap' ]"
            >
              {{ item.備註 }}
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scpoe>
::-webkit-scrollbar {
  display: none;
}
</style>
