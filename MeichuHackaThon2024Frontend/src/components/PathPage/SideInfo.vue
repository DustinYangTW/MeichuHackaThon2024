<script setup lang="ts">
import RadialProgress from "vue3-radial-progress";

defineProps<{
  costTime: string;
  completedSteps: number;
  totalSteps: number;
  transport: {
    type: "公車" | "Bike" | "步行";
    remark: string;
  };
}>();
</script>

<template>
  <div class="w-full h-fit flex justify-center items-center">
    <RadialProgress
      :diameter="110"
      :completed-steps="completedSteps"
      :total-steps="totalSteps"
    >
      <div class="flex flex-col justify-center items-center">
        <div class="text-lg font-extrabold">抵達:</div>
        <span class="text-xl font-extrabold"
          >{{ completedSteps }} / {{ totalSteps }}</span
        >
      </div>
    </RadialProgress>
  </div>
  <div class="h-[2px] w-full bg-white opacity-30 my-4 text-white" />
  <div class="flex flex-col gap-1">
    <div class="text-sm opacity-70">估計花費時間</div>
    <div class="text-2xl font-semibold text-center">
      {{ costTime }}
    </div>
  </div>
  <div class="h-[2px] w-full bg-white opacity-30 my-4" />
  <div class="flex flex-col gap-1">
    <div class="text-sm opacity-70">交通種類</div>
    <div class="flex flex-col text-2xl py-2">
      <div v-if="!transport.type">-</div>
      <font-awesome-icon
        v-if="transport.type === '步行'"
        :icon="['fas', 'shoe-prints']"
      />
      <template v-if="transport.type === 'Bike'">
        <div class="flex justify-center items-center gap-2">
          <font-awesome-icon
            v-if="transport.type === 'Bike'"
            :icon="['fas', 'bicycle']"
          />
          <div class="text-xl">
            {{ transport.remark }}
          </div>
        </div>
      </template>
      <template v-if="transport.type === '公車'">
        <div class="flex justify-center items-center gap-2">
          <font-awesome-icon
            v-if="transport.type === '公車'"
            :icon="['fas', 'bus']"
          />
          <div class="text-xl">{{ transport.remark }} 號</div>
        </div>
      </template>
      <template v-if="transport.type === '共乘'">
        <div class="flex justify-center items-center gap-2">
          <font-awesome-icon
            v-if="transport.type === '共乘'"
            :icon="['fas', 'car-side']"
          />
          <div class="text-xl">{{ transport.remark }}</div>
        </div>
      </template>
    </div>
  </div>
</template>
