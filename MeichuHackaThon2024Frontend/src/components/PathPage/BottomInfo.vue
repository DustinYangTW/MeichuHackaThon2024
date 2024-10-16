<script setup lang='ts'>
import type { PathDetail } from '@/type';

const emit = defineEmits<{
  (e: 'nextStep'): void
  (e: 'previousStep'): void
}>();

const isColddown = ref<boolean>(false);

const colddown = () => {
  isColddown.value = true;
  setTimeout(() => {
    isColddown.value = false;
  }, 1500);
}

const previousStep = () => {
  if (isColddown.value) {
    return;
  }

  emit('previousStep');
  colddown();
}

const nextStep = () => {
  if (isColddown.value) {
    return;
  }

  emit('nextStep');
  colddown();
}

const { hasNextStep = false, hasPreviousStep = false } = defineProps<{
  data: PathDetail;
  hasNextStep: boolean;
  hasPreviousStep: boolean;
}>();
</script>

<template>
  <div class="w-full h-full flex justify-around items-center">
    <div
      class="text-2xl flex justify-center px-8 py-2 rounded-full bg-gray-500 cursor-pointer w-[65px]"
      :class="{ 'opacity-50': !hasPreviousStep }"
      @click="previousStep"
    >
      <font-awesome-icon :icon="['fas', 'backward-step']" />
    </div>
    <div class="w-full py-5 px-8 flex justify-center items-center">
      <div class="w-fit whitespace-nowrap text-xl font-bold">
        {{ data.location?.name ?? '-' }}
      </div>
      <div class="w-full h-full border-[2px] border-dashed border-white mx-8 max-w-[300px]" />
      <div class="w-fit whitespace-nowrap text-xl font-bold">
        {{ data.destination?.name ?? '-' }}
      </div>
    </div>
    <div
      class="text-2xl flex justify-center px-8 py-2 rounded-full bg-gray-500 cursor-pointer w-[65px]"
      @click="nextStep"
    >
      <font-awesome-icon v-if="!hasNextStep" :icon="['fas', 'street-view']" />
      <font-awesome-icon v-else :icon="['fas', 'forward-step']" />
    </div>
  </div>
</template>
