import axios from "axios";
import type { Path } from "../api/type";
import type { Response } from "./transformResponse";
import { transformResponse } from "./transformResponse";

export interface GetPathListPayload {
  /**
   * 目的地名稱
   */
  des: string;
  /**
   * 出發地名稱
   */
  loc: string;
}

/**
 * 取得路徑列表
 * @param {GetPathListPayload} payload
 * @param {string} payload.des - 目的地名稱
 * @param {string} payload.loc - 出發地名稱
 * @returns {Promise<Response>} 回傳路徑列表
 */
export async function getPathList(
  payload: GetPathListPayload
): Promise<Response<Path[]>> {
  const { des, loc } = payload;
  try {
    // const response = await axios.get<Response>('/getPathList', {
    //   params: {
    //     des,
    //     loc
    //   }
    // });

    const response: Path[] = await new Promise((resolve, reject) => {
      setTimeout(() => {
        resolve(mockPathData);
      }, 1500);
    });

    return transformResponse({
      code: "0001",
      msg: "success",
      data: response,
    });
  } catch (error) {
    console.error("Error fetching fuzzy search list:", error);
    throw new Error("Failed to fetch fuzzy search list");
  }
}

export const mockPathData: Path[] = [
  {
    id: 1,
    destination: "城隍廟前廣場",
    location: "國立陽明交通大學體育館",
    costTime: "35m",
    arrivalTime: "09:04",
    transportComp: {
      公車: 84,
      Bike: 0,
      步行: 16,
      共乘: 0,
    },
    crowding: 0,
    path_details: [
      {
        location: {
          gps: {
            lat: "120.99573786220625",
            lng: "24.788946082114585",
          },
          name: "國立陽明交通大學體育館",
        },
        destination: {
          gps: {
            lat: "120.99754927480843",
            lng: "24.796508074536952",
          },
          name: "清華大學",
        },
        costTime: "16分",
        arrivalTime: "08:00",
        transport: {
          type: "步行",
          remark: "步行",
        },
        crowding: 2,
      },
      {
        location: {
          gps: {
            lat: "120.99754927480843",
            lng: "24.796508074536952",
          },
          name: "清華大學",
        },
        destination: {
          gps: {
            lat: " 120.97101060750855",
            lng: "24.803320896069028",
          },
          name: "新竹火車站(中正路)",
        },
        costTime: "11分",
        arrivalTime: "08:13",
        transport: {
          type: "公車",
          remark: "5608",
        },
        crowding: 4,
      },
      {
        location: {
          gps: {
            lat: " 120.97101060750855",
            lng: "24.803320896069028",
          },
          name: "新竹火車站(中正路)",
        },
        destination: {
          gps: {
            lat: " 120.96593168750877",
            lng: "24.80445711912709",
          },
          name: "新竹都城隍廟",
        },
        costTime: "8分",
        arrivalTime: "08:13",
        transport: {
          type: "步行",
          remark: "步行",
        },
        crowding: 4,
      },
    ],
  },
  {
    id: 2,
    destination: "城隍廟前廣場",
    location: "國立陽明交通大學體育館",
    costTime: "42m",
    arrivalTime: "09:04",
    transportComp: {
      公車: 90,
      Bike: 0,
      步行: 10,
      共乘: 0,
    },
    crowding: 0,
    path_details: [
      {
        location: {
          gps: {
            lat: "120.99573786220625",
            lng: "24.788946082114585",
          },
          name: "國立陽明交通大學體育館",
        },
        destination: {
          gps: {
            lat: "120.99941877283285",
            lng: "24.788299026754014",
          },
          name: "交大光復校區",
        },
        costTime: "7分",
        arrivalTime: "08:00",
        transport: {
          type: "步行",
          remark: "步行",
        },
        crowding: 2,
      },
      {
        location: {
          gps: {
            lat: "120.99941877283285",
            lng: "24.788299026754014",
          },
          name: "交大光復校區",
        },
        destination: {
          gps: {
            lat: "120.96933763923636",
            lng: "24.80548842304441",
          },
          name: "東門市場",
        },
        costTime: "28分",
        arrivalTime: "08:13",
        transport: {
          type: "公車",
          remark: "2A經建功高中",
        },
        crowding: 4,
      },
      {
        location: {
          gps: {
            lat: "120.96933763923636",
            lng: "24.80548842304441",
          },
          name: "東門市場",
        },
        destination: {
          gps: {
            lat: "120.96597468181294",
            lng: "24.805040672214925",
          },
          name: "城隍廟前廣場",
        },
        costTime: "7分",
        arrivalTime: "08:23",
        transport: {
          type: "步行",
          remark: "步行",
        },
        crowding: 1,
      },
    ],
  },
  {
    id: 3,
    destination: "城隍廟前廣場",
    location: "國立陽明交通大學體育館",
    costTime: "51m",
    arrivalTime: "09:04",
    transportComp: {
      公車: 0,
      Bike: 20,
      步行: 53,
      共乘: 27,
    },
    crowding: 0,
    path_details: [
      {
        location: {
          gps: {
            lat: "120.99573786220625",
            lng: "24.788946082114585",
          },
          name: "國立陽明交通大學體育館",
        },
        destination: {
          gps: {
            lat: "120.99939195216426",
            lng: "24.788310883357507",
          },
          name: "交大光復校區",
        },
        costTime: "7分",
        arrivalTime: "08:00",
        transport: {
          type: "步行",
          remark: "步行",
        },
        crowding: 2,
      },
      {
        location: {
          gps: {
            lat: "120.99939195216426",
            lng: "24.788310883357507",
          },
          name: "交大光復校區",
        },
        destination: {
          gps: {
            lat: "121.00240561038945",
            lng: "24.79267822031121",
          },
          name: "陽明交大光復路(過溝)",
        },
        costTime: "14分",
        arrivalTime: "08:23",
        transport: {
          type: "步行",
          remark: "步行",
        },
        crowding: 1,
      },
      {
        location: {
          gps: {
            lat: "121.00240561038945",
            lng: "24.79267822031121",
          },
          name: "陽明交大光復路(過溝)",
        },
        destination: {
          gps: {
            lat: "120.98310352069274",
            lng: "24.802410321639847",
          },
          name: "食品路口",
        },
        costTime: "14分",
        arrivalTime: "08:23",
        transport: {
          type: "共乘",
          remark: "動物園線",
        },
        crowding: 1,
      },
      {
        location: {
          gps: {
            lat: "120.98310352069274",
            lng: "24.802410321639847",
          },
          name: "食品路口",
        },
        destination: {
          gps: {
            lat: "120.98096502386976",
            lng: "24.800197579066086",
          },
          name: "YouBike 新竹動物園",
        },
        costTime: "6分",
        arrivalTime: "08:23",
        transport: {
          type: "步行",
          remark: "步行",
        },
        crowding: 1,
      },
      {
        location: {
          gps: {
            lat: "120.98096502386976",
            lng: "24.800197579066086",
          },
          name: "YouBike 新竹動物園",
        },
        destination: {
          gps: {
            lat: "120.96599065443802",
            lng: "24.80477590112634",
          },
          name: "城隍廟前廣場",
        },
        costTime: "10分",
        arrivalTime: "08:23",
        transport: {
          type: "Bike",
          remark: "新竹動物園站",
        },
        crowding: 1,
      },
    ],
  },
];
