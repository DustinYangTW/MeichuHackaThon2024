<script setup lang='ts'>
const menuStatus = ref(true);

const router = useRouter();

const routerList = ref<{
  name: string,
  path: string,
}[]>([]);

onMounted(() => {
  routerList.value = router.getRoutes().map((route) => ({
    name: route.name as string,
    path: route.path,
  }));
});
</script>

<template>
  <div class="flex flex-col px-4 py-2">
    <div class="flex justify-end">
      <div v-if="menuStatus" class="text-3xl cursor-pointer" @click="menuStatus = false">
        <font-awesome-icon :icon="['fas', 'bars']" />
      </div>
      <div v-else class="text-3xl cursor-pointer" @click="menuStatus = true">
        <font-awesome-icon :icon="['fas', 'caret-down']" />
        <nav class="absolute top-[40px] right-4 flex flex-col text-lg text-gray-500 p-3 bg-white rounded-md">
          <RouterLink
            v-for="(item, index) in routerList"
            :key="index"
            :to="item.path"
            class="hover:bg-gray-200 px-2"
            :class="router.currentRoute.value.name === item.name ? 'bg-gray-200' : ''"
          >
            {{ item.name }}
          </RouterLink>
        </nav>
      </div>
    </div>
    <RouterView />
  </div>
</template>

<style lang="scss" scoped>

</style>
