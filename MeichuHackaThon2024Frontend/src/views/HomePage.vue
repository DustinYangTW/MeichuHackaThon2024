<script setup lang="ts">
import { useImagesStore } from '@/stores/images';

const imagesStore = useImagesStore()

const currentIndex = ref<number>(0)
const search = ref<string>('')
const searchTmp = ref<string>('')

const nextImage = () => {
  currentIndex.value = (currentIndex.value + 1) % imagesStore.HomePageBg.length;
};

const fuzzySearch = () => {
  if (searchTmp.value === search.value || search.value === '') {
    return;
  }
  searchTmp.value = search.value;
  console.log(`q = ${search.value}`);
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
    <div class="w-full text-2xl sm:text-4xl md:text-5xl font-medium">
      Welcome to 新竹
    </div>
    <div class="w-full text-4xl sm:text-6xl md:text-8xl py-4 font-extrabold">
      開始你的旅程吧
    </div>
    <div class="w-full flex flex-wrap gap-3">
      <input
        v-model="search"
        @input="fuzzySearch"
        type="text"
        class="rounded-2xl bg-gray-500 px-6 text-white text-2xl opacity-70 w-[250px] sm:w-[400px] md:w-[500px] h-[65px]"
        placeholder="Search place, location"
      >
      <button
        class="text-2xl p-4 bg-white text-black rounded-2xl w-[65px] h-[65px] flex justify-center items-center hover:scale-110"
      >
        <font-awesome-icon :icon="['fas', 'magnifying-glass']" />
      </button>
    </div>
  </div>
</template>
