<script setup lang="ts">

type Path = {
  /**
   * 路徑編號
   */
  id: number;
  /**
   * 目的地名稱
   * @example ‘青青草原’ | ‘新竹體育館’
   */
  destination: string;
  /**
   * 本地位置名稱
   * @example ‘本地’ | '陽明交大'
   */
  location: string;
  /**
   * 耗時
   * @example "1h 30m"
   */
  costTime: string;
  /**
   * 到達時間
   * @example "11:30"
   */
  arrivalTime: string,
  /**
   * 交通工具種類以及%數
   */
  transportComp: Record<'公車' | 'Bike' | '步行', number>
  /**
   * 擁擠程度
   */
  crowding: number,
  /**
   * 子路徑選項
   */
  path_details: PathDetail[]
}

type PathDetail = {
  destination: {
    gps: string;
    name: string;
  };
  location: {
    gps: string;
    name: string;
  };
  costTime: string;
  arrivalTime: string;
  transport: {
    type: '公車' | 'Bike' | '步行';
    remark: string;
  };
  crowding: number;
}

const mockData: Path = {
  id: 1,
  destination: '青青草原',
  location: '國立陽明交通大學體育館',
  costTime: '1h 4m',
  arrivalTime: '09:04',
  transportComp: {
    '公車': 33,
    'Bike': 17,
    '步行': 17
  },
  crowding: 0,
  path_details: [
    {
      destination: {
        gps: '24.791641, 120.997713',
        name: '國立陽明交通大學體育館'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '生科館人社院'
      },
      costTime: '13分',
      arrivalTime: '08:00',
      transport: {
        type: '步行',
        remark: '步行'
      },
      crowding: 2
    },
    {
      destination: {
        gps: '24.791641, 120.997713',
        name: '生科館人社院'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '新竹轉運站'
      },
      costTime: '10分',
      arrivalTime: '08:13',
      transport: {
        type: '公車',
        remark: '83'
      },
      crowding: 4
    },
    {
      destination: {
        gps: '24.791641, 120.997713',
        name: '新竹轉運站'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '新竹火車站(中正路)'
      },
      costTime: '5分',
      arrivalTime: '08:23',
      transport: {
        type: '步行',
        remark: '步行'
      },
      crowding: 1
    },
    {
      destination: {
        gps: '24.791641, 120.997713',
        name: '新竹火車站(中正路)'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '朝山'
      },
      costTime: '20分',
      arrivalTime: '08:28',
      transport: {
        type: '公車',
        remark: '公車編號 5801'
      },
      crowding: 3
    },
    {
      destination: {
        gps: '24.791641, 120.997713',
        name: '朝山'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '香山天后宮'
      },
      costTime: '5分',
      arrivalTime: '08:48',
      transport: {
        type: '步行',
        remark: '步行'
      },
      crowding: 3
    },
    {
      destination: {
        gps: '24.791641, 120.997713',
        name: '香山天后宮'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '青青草原'
      },
      costTime: '16分',
      arrivalTime: '09:04',
      transport: {
        type: 'Bike',
        remark: '香山天后宮站'
      },
      crowding: 1
    }
  ],
};

const route = useRoute();
const data = ref();

onMounted(async() => {
  const { id } = route.query;

  // todo 未正確傳遞 query string value 導回首頁
  if(!id) {
    console.log('路徑編號錯誤');
    return;
  }

  const response: Path = await new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve(mockData);
    }, 1500);
  })

  data.value = response;
})
</script>

<template>
  <div
    class="w-full h-full flex flex-col items-center p-4 text-white"
  >
    <h1>路徑頁 {{ data }}</h1>
  </div>
</template>
