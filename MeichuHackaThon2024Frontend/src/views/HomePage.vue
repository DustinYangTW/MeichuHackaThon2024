<script setup lang="ts">
import { useImagesStore } from '@/stores/images';

const imagesStore = useImagesStore()

const currentIndex = ref(0);

const nextImage = () => {
  currentIndex.value = (currentIndex.value + 1) % imagesStore.HomePageBg.length;
};

onMounted(() => {
  const intervalId = setInterval(nextImage, 3000);
  onUnmounted(() => clearInterval(intervalId));
  console.log('homepage');
})
</script>

<template>
  <div
    class="w-full h-full bg-cover bg-no-repeat bg-center duration-1000 flex flex-col justify-end items-center pb-36 pl-8"
    :style="{ backgroundImage: `url(${imagesStore.HomePageBg[currentIndex]})` }"
  >
    <div class="w-full text-2xl sm:text-4xl md:text-5xl font-medium">
      Welcome to 新竹
    </div>
    <div class="w-full text-4xl sm:text-6xl md:text-8xl py-4 font-extrabold">
      開始你的旅程吧
    </div>
    <div class="w-full flex gap-3">
      <input type="text" class="rounded-2xl bg-gray-500 px-6 text-white text-xl opacity-70 w-[250px] sm:w-[400px] md:w-[500px]" placeholder="Search place, location">
      <button class="text-2xl p-4 bg-white text-black rounded-2xl">
        <font-awesome-icon :icon="['fas', 'magnifying-glass']" />
      </button>
    </div>
  </div>
</template>
