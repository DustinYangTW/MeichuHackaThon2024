<script setup lang="ts">
import type { Path } from "@/type";

const { path } = defineProps<{
  path: Path;
}>();
</script>

<template>
  <slot></slot>
  <div
    class="min-w-fit w-[50%] cursor-pointer rounded-lg bg-slate-700 hover:bg-[rgb(71,85,105,0.9)] text-white py-3 px-2 font-bold text-3xl text-center peer-checked:bg-[rgb(71,85,105,0.9)] bg-opacity-60"
  >
    <label :for="path.id.toString()">
      <slot name="content">
        <font-awesome-icon :icon="['fas', 'clock']" />
        <h3 class="inline">{{ path.costTime }}</h3>
        <hr class="border-white rounded-full py-2" />

        <div class="flex gap-2 text-2xl p-4">
          <div>
            <font-awesome-icon :icon="['fas', 'shoe-prints']" />
            <span>{{ `${path.transportComp.步行} %` }}</span>
          </div>
          <div>
            <font-awesome-icon :icon="['fas', 'bicycle']" />
            <span>{{ `${path.transportComp.Bike} %` }}</span>
          </div>
          <div>
            <font-awesome-icon :icon="['fas', 'bus']" />
            <span>{{ `${path.transportComp.公車} %` }}</span>
          </div>
        </div>
      </slot>
    </label>
  </div>
</template>
