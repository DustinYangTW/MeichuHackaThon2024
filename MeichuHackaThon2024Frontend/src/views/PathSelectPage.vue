<script setup lang="ts">
import { getPathList } from '@/api';
import type { GetPathListPayload } from '@/api';
import type { Path } from '@/type';

const route = useRoute();

const data = ref<Path[]>([]);
const recommendList = ref([]);

onMounted(async () => {
  const { q } = route.query;

  // todo 未正確傳遞 query string value 導回首頁
  if(!q) {
    return;
  }

  const payload: GetPathListPayload = {
    des: q as string,
    loc: q as string,
  }

  const response = await getPathList(payload);

  if(!response.success) {
    return;
  }

  data.value = response.data;

  console.log(response);
})
</script>

<template>
  <div
    class="w-full h-full bg-gray-900 duration-1000 flex flex-col justify-start items-center pt-12 pl-8 gap-12 select-none"
  >
    <div class="overflow-x-scroll">
      <div v-if="data.length === 0">
        empty
      </div>
      <div
        v-else
        class="flex flex-wrap justify-center gap-3 relative"
      >
        <div
          v-for="(item, index) in data" :key="`${item}-${index}`"
          class="flex flex-col px-5 py-4 bg-gray-800 rounded-xl bg-cover bg-no-repeat bg-center w-[500px] h-[350px] relative"
        >
          <div class="absolute bottom-2 w-[480px] left-1/2 -translate-x-1/2 bg-white rounded-xl text-black px-4 py-3 flex flex-col gap-[1px]">
            <div class="text-xl font-bold flex justify-between">
              <div class="font-black">
                {{ item.costTime }}
              </div>
              <div class="text-blue-500 cursor-pointer hover:text-blue-800" @click="console.log('go');">
                <font-awesome-icon :icon="['fas', 'person-walking-dashed-line-arrow-right']" />
                出發
              </div>
            </div>
            <div class="text-base">
              {{ item.crowding }}
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scpoe>
::-webkit-scrollbar {
  display: none;
}
</style>
