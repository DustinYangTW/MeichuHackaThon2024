<script setup lang="ts">
import { Fireworks } from 'fireworks-js'


onMounted(() => {
  const container = document.getElementById('firework')!
  const fireworks = new Fireworks(container, {
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

  fireworks.start()

})
</script>

<template>
  <div class="absolute w-[100dvw] h-[100dvh] top-0 left-0" id="firework">
    <div class="absolute top-0 left-0 w-full h-full backdrop-blur-[1px]" />
    <div class="absolute top-1/2 left-1/2 -translate-x-1/2 -translate-y-1/2 w-1/3 h-1/3 rounded-xl bg-white text-black flex justify-center items-center">
      <div class="text-9xl text-black font-extrabold">
        finish
      </div>
    </div>
  </div>
</template>