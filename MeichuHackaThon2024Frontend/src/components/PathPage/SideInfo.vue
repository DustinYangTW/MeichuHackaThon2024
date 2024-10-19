<script setup lang='ts'>
import RadialProgress from "vue3-radial-progress";

defineProps<{
  costTime: string;
  completedSteps: number;
  totalSteps: number;
  transport: {
    type: '公車' | 'Bike' | '步行';
    remark: string;
  };
}>();
</script>

<template>
  <div class="w-fit h-fit">
    <RadialProgress
      :diameter="150"
      :completed-steps="completedSteps"
      :total-steps="totalSteps"
    >
      <div class="flex flex-col justify-center items-center">
        <div class="text-xl font-extrabold">抵達: </div>
        <span class="text-2xl font-extrabold">{{ completedSteps }} / {{ totalSteps }}</span>
      </div>
    </RadialProgress>
  </div>
  <div class="h-[2px] w-full bg-white opacity-30 my-4" />
  <div class="flex flex-col gap-1">
    <div class="text-sm">
      估計花費時間
    </div>
    <div class="text-3xl font-semibold text-center">
      {{ costTime }}
    </div>
  </div>
  <div class="h-[2px] w-full bg-white opacity-30 my-4" />
  <div class="flex flex-col gap-1">
    <div class="text-sm">
      交通種類
    </div>
    <div class="flex flex-col text-3xl py-2">
      <div v-if="!transport.type">
        -
      </div>
      <font-awesome-icon v-if="transport.type === '步行'" :icon="['fas', 'shoe-prints']" />
      <font-awesome-icon v-if="transport.type === 'Bike'" :icon="['fas', 'bicycle']" />
      <font-awesome-icon v-if="transport.type === '公車'" :icon="['fas', 'bus']" />
    </div>
  </div>
</template>
