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
    class="w-full h-full bg-cover bg-no-repeat bg-center"
    :style="{ backgroundImage: `url(${imagesStore.HomePageBg[currentIndex]})` }"
  >
    <h1>首頁</h1>
  </div>
</template>
