<template>
  <div class="z-20 absolute w-[100dvw] h-[100dvh] top-0 left-0">
    <div class="absolute top-0 left-0 w-full h-full backdrop-blur-sm" />
    <div class="absolute top-1/2 left-1/2 -translate-x-1/2 -translate-y-1/2 w-1/3 h-1/3 rounded-xl flex justify-center items-center">
      <div class="text-[240px] text-gray-600 font-extrabold animate-spin duration-500">
        <font-awesome-icon :icon="['fas', 'spinner']" />
      </div>
    </div>
  </div>
</template>