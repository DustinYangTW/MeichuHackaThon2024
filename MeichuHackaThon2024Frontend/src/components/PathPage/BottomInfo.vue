<script setup lang='ts'>
import type { PathDetail } from '@/type';

const emit = defineEmits<{
  (e: 'nextStep'): void
  (e: 'previousStep'): void
}>();

const previousStep = () => {
  if (hasPreviousStep) {
    emit('previousStep');
  }
}

const nextStep = () => {
  if (hasNextStep) {
    emit('nextStep');
  }
}

const { hasNextStep, hasPreviousStep } = defineProps<{
  data: PathDetail;
  hasNextStep: boolean;
  hasPreviousStep: boolean;
}>();
</script>

<template>
  <div class="flex justify-around items-center">
    <div
      class="text-2xl flex justify-center px-8 py-2 rounded-full bg-gray-500 cursor-pointer"
      :class="{ 'opacity-50': !hasPreviousStep }"
      @click="previousStep"
    >
      <font-awesome-icon :icon="['fas', 'backward-step']" />
    </div>
    {{ data.location?.name ?? '-' }} - {{ data.destination?.name ?? '-' }}
    <div
      class="text-2xl flex justify-center px-8 py-2 rounded-full bg-gray-500 cursor-pointer"
      :class="{ 'opacity-50': !hasNextStep }"
      @click="nextStep"
    >
      <font-awesome-icon :icon="['fas', 'forward-step']" />
    </div>
  </div>
</template>
