<script setup lang="ts">
import Layout from './layout/Layout.vue'
import { useImagesStore } from './stores/images';

const imagesStore = useImagesStore()

onBeforeMount(() => {
  imagesStore.preLoadImages();
})
</script>

<template>
  <Layout />
</template>
