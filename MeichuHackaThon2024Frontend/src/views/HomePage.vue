<script setup lang="ts">
import { useImagesStore } from '@/stores/images';

const mockData = [
  '青青草原', '青草公園', '新竹體育館', '新竹舊派出所', '薰衣草森林', '新竹尖石', '小叮噹科學主題樂園', '十八尖山', '新竹市立動物園', '新竹都城煌廟'
]

const imagesStore = useImagesStore()
const router = useRouter();

const currentIndex = ref<number>(0)
const search = ref<string>('')
const searchTmp = ref<string>('')
const searchAlert = ref(false)
const fuzzyList = ref<string[]>(mockData);
const fuzzyDialog = ref(false);

const nextImage = () => {
  currentIndex.value = (currentIndex.value + 1) % imagesStore.HomePageBg.length;
};

const selectFromList = (item: string) => {
  search.value = item;
  fuzzyDialog.value = false;
  fuzzySearch();
}

const fuzzySearch = () => {
  fuzzyList.value = mockData.filter((item) => item.includes(search.value));
  if (searchTmp.value === search.value || search.value === '') {
    return;
  }
  searchAlert.value = false;
  searchTmp.value = search.value;
}

const searchPath = () => {
  if (!mockData.includes(search.value)) {
    searchAlert.value = true;
    return;
  }

  router.push({ name: 'PathSelectPage', query: { q: search.value } });
}

onMounted(() => {
  const intervalId = setInterval(nextImage, 3000);
  onUnmounted(() => clearInterval(intervalId));
})
</script>

<template>
  <div
    class="w-full h-full bg-cover bg-no-repeat bg-center duration-1000 flex flex-col justify-end items-center pb-36 pl-8 text-white"
    :style="{ backgroundImage: `url(${imagesStore.HomePageBg[currentIndex]})` }"
  >
    <div v-if="fuzzyDialog" class="absolute top-0 left-0 w-[100vw] h-[100vh] z-0" @click="fuzzyDialog = false" />
    <div class="w-full text-white text-2xl sm:text-4xl md:text-5xl font-medium">
      Welcome to 新竹
    </div>
    <div class="w-full text-white text-4xl sm:text-6xl md:text-8xl py-4 font-extrabold">
      開始你的旅程吧
    </div>
    <div class="w-full flex flex-wrap gap-3 relative">
      <div
        v-if="fuzzyDialog"
        class="absolute left-0 w-[250px] sm:w-[400px] md:w-[500px] bg-white rounded-2xl overflow-y-auto text-black z-10"
        :style="{
          height: Math.min(fuzzyList.length * 50, 250) + 'px',
          top: '-' + Math.min(fuzzyList.length * 50 + 5, 255) + 'px'
        }"
      >
        <div
          v-for="item in fuzzyList"
          class="bg-gray-100 h-[50px] flex justify-start items-center pl-3 text-xl hover:bg-gray-300 hover:text-2xl hover:font-bold cursor-pointer"
          @click="selectFromList(item)"
        >
          {{ item }}
        </div>
      </div>
      <input
        v-on:focus="() => fuzzyDialog = true"
        v-model="search"
        @input="fuzzySearch"
        type="text"
        class="rounded-2xl bg-gray-500 px-6 text-white text-2xl opacity-70 w-[250px] sm:w-[400px] md:w-[500px] h-[65px]"
        :class="[ searchAlert ? 'border-4 border-red-500' : 'border-4 border-transparent']"
        placeholder="Search place, location"
      >
      <button
        class="text-2xl p-4 bg-white text-black rounded-2xl w-[65px] h-[65px] flex justify-center items-center hover:scale-110"
        @click="searchPath"
      >
        <font-awesome-icon :icon="['fas', 'magnifying-glass']" />
      </button>
    </div>
  </div>
</template>

<style scpoe>
::-webkit-scrollbar {
  display: none;
}
</style>
