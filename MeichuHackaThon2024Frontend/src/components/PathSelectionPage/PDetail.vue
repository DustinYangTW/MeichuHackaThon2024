<script setup lang="ts">
import type { PathDetail } from "@/type";
import Icon from "@/components/PathSelectionPage/Icon.vue";
const { detail } = defineProps<{ detail: PathDetail }>();
console.log(detail);
</script>

<template>
  <div
    class="w-[90%] rounded-lg bg-[rgb(71,85,105,0.9)] text-white font-bold text-[length:inherit] text-center mx-auto px-2 py-1 my-1"
  >
    <div class="flex items-center gap-2 max-w-full py-1">
      <Icon :trasport-type="detail.transport.type" />
      <span class="text-2xl text-nowrap">{{ detail.transport.remark }}</span>
      <span class="text-2xl ml-auto">{{ detail.costTime }}</span>
    </div>
  </div>
</template>
