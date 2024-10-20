<script setup lang="ts">
import type { vehicle } from "@/api/type";
const { trasportType } = defineProps<{ trasportType: vehicle }>();
</script>
<template>
  <span>
    <font-awesome-icon :icon="['fas', 'bus']" v-if="trasportType === '公車'" />
    <font-awesome-icon
      :icon="['fas', 'bicycle']"
      v-else-if="trasportType === 'Bike'"
    />
    <font-awesome-icon
      :icon="['fas', 'shoe-prints']"
      v-else-if="trasportType === '步行'"
    />
    <font-awesome-icon
      :icon="['fas', 'car-side']"
      v-else-if="trasportType === '共乘'"
    />
  </span>
</template>
