<script setup lang="ts">
import type { Path } from "@/type";

const { path } = defineProps<{
  path: Path;
}>();
</script>

<template>
  <div
    class="w-full cursor-pointer bg-gray-800 hover:bg-gray-900 text-white py-3 px-2 font-bold text-3xl text-center select-none"
  >
    <label :for="path.id.toString()">
      <slot name="content">
        <font-awesome-icon :icon="['fa', 'clock']" class="text-2xl" />
        <h3 class="inline">{{ path.costTime }}</h3>
        <hr class="border-white rounded-full py-2" />

        <div class="flex gap-4 text-xl px-4 pb-4 pt-2">
          <div class="flex gap-1 justify-center items-center">
            <font-awesome-icon :icon="['fas', 'shoe-prints']" />
            <span class="flex justify-center items-center">
              <div>
                {{ path.transportComp.步行 }}
              </div>
              <div>%</div>
            </span>
          </div>
          <div class="flex gap-1 justify-center items-center">
            <font-awesome-icon :icon="['fas', 'bicycle']" />
            <span class="flex justify-center items-center">
              <div>
                {{ path.transportComp.Bike }}
              </div>
              <div>%</div>
            </span>
          </div>
          <div class="flex gap-1 justify-center items-center">
            <font-awesome-icon :icon="['fas', 'bus']" />
            <span class="flex justify-center items-center">
              <div>
                {{ path.transportComp.公車 }}
              </div>
              <div>%</div>
            </span>
          </div>

          <div class="flex gap-1 justify-center items-center">
            <font-awesome-icon :icon="['fas', 'car-side']" />
            <span class="flex justify-center items-center">
              <div>
                {{ path.transportComp.共乘 ?? 0 }}
              </div>
              <div>%</div>
            </span>
          </div>
        </div>
      </slot>
    </label>
  </div>
</template>
