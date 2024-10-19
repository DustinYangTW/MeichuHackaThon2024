<script setup lang="ts">
import { Fireworks } from 'fireworks-js'

const router = useRouter();

const { title } = defineProps<{
  title: string
}>();

const emit = defineEmits<{
  (e: 'close'): void
}>();

const targetElement = ref<HTMLElement | null>(null);

const fireworks = ref<Fireworks | null>(null);

const close = () => {
  fireworks.value!.stop()

  emit('close');

  router.push({
    name: 'home'
  })
}

onMounted(() => {
  targetElement.value = document.getElementById('firework')!

  fireworks.value = new Fireworks(targetElement.value, {
    autoresize: true,
    opacity: 0.9,
    acceleration: 1.05,
    friction: 0.97,
    gravity: 1.5,
    particles: 50,
    traceLength: 3,
    traceSpeed: 10,
    explosion: 5,
    intensity: 30,
    flickering: 50,
    lineStyle: 'round',
    hue: {
      min: 0,
      max: 360
    },
    delay: {
      min: 30,
      max: 60
    },
    rocketsPoint: {
      min: 50,
      max: 50
    },
    lineWidth: {
      explosion: {
        min: 1,
        max: 3
      },
      trace: {
        min: 1,
        max: 2
      }
    },
    brightness: {
      min: 50,
      max: 80
    },
    decay: {
      min: 0.015,
      max: 0.03
    },
    mouse: {
      click: false,
      move: false,
      max: 1
    }
  })

  if (title === '抵達') {
    fireworks.value.start()
  }
})
</script>

<template>
  <div class="z-20 absolute w-[100dvw] h-[100dvh] top-0 left-0" id="firework">
    <div class="absolute top-0 left-0 w-full h-full backdrop-blur-[1px]" />
    <div class="absolute top-1/2 left-1/2 -translate-x-1/2 -translate-y-1/2 w-1/3 h-1/3 rounded-xl bg-gray-800 text-black flex flex-col justify-center items-center p-8">
      <div class="h-full p-6 text-5xl text-white font-extrabold flex justify-center items-center">
        {{ title }}
      </div>
      <button
        class="w-full py-2 rounded-full bg-gray-400 hover:bg-gray-500 text-2xl font-bold"
        @click="close"
      >
        結束
      </button>
    </div>
  </div>
</template>