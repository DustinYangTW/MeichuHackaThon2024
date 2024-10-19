<script setup lang="ts">
import type { GetPathListPayload } from "@/api";
import { getPathList } from "@/api";
import PathCard from "@/components/PathSelectionPage/PathCard.vue";
import PDetail from "@/components/PathSelectionPage/PDetail.vue";
import type { Path, PathDetail } from "@/type";

const route = useRoute();
let response;
const pathData = ref<Path[]>([]);
onMounted(async () => {
  const { q } = route.query;

  const payload: GetPathListPayload = {
    des: q as string,
    loc: q as string,
  };
  response = await getPathList(payload);
  pathData.value = response.data;
});

const calctime = (s: string) => {
  const timePartition = s.split(" ");

  if (timePartition.length == 1) {
    let minString = timePartition[0];
    const extraIndex = minString.match(/m/)?.index;
    return Number.parseInt(minString.slice(extraIndex));
  }

  let hourString = timePartition[0],
    minString = timePartition[1];
  const extraInd1 = hourString.match(/h/)?.index;
  const extraInd2 = minString.match(/m/)?.index;

  const hours = Number.parseInt(hourString.slice(extraInd1));
  const mins = Number.parseInt(minString.slice(extraInd2));
  return hours * 60 + mins;
};

const calcPercentage = (
  details: PathDetail[],
  type: "公車" | "Bike" | "步行"
) => {
  const total = details.reduce((acc, cur) => calctime(cur.costTime) + acc, 0);
  const timePortion = details
    .filter(each => typeof each.transport.type === typeof type)
    .reduce((acc, cur) => calctime(cur.costTime) + acc, 0);

  const percentage = `${Math.round(total / timePortion)} %`;
  return percentage;
};
</script>

<template>
  <nav class="h-auto z-10">
    <ul class="w-1/3 h-full list-none">
      <li v-for="path in pathData" :key="path.id" class="my-2 relative w-fit">
        <PathCard :path="path">
          <!-- 這裡需要假資料包含不重複的id才能正常運作 -->
          <input
            type="checkbox"
            :id="path.id.toString()"
            class="peer opacity-0 h-0"
          />
        </PathCard>
        <ul
          role="menu"
          class="opacity-0 h-0 peer-checked:h-auto peer-checked:opacity-100"
        >
          <li role="menuitem">
            <PDetail v-for="d in path.path_details" :detail="d"></PDetail>
          </li>
        </ul>
      </li>
    </ul>
  </nav>
  <!-- 還沒接地圖+沒找到最新push的commit -->
</template>

<style scpoe>
::-webkit-scrollbar {
  display: none;
}
</style>
