import axios from 'axios';
import type { Path } from './type';
import type { Response } from './transformResponse';
import { transformResponse } from './transformResponse';

export interface GetPathDetailListPayload {
  /**
   * 路徑編號
   */
  id: number;
}

/**
 * 取得路徑詳細列表
 */
export async function getPathDetailList(payload: GetPathDetailListPayload): Promise<Response<Path>> {
  const { id } = payload;
  try {
    // const response = await axios.get<Response>('/getPathDetailList', {
    //   params: {
    //     id
    //   }
    // });

    const response: Path = await new Promise((resolve, reject) => {
      setTimeout(() => {
        resolve(mockData);
      }, 1500);
    })

    return transformResponse({
      code: '0001',
      msg: 'success',
      data: response
    });
  } catch (error) {
    console.error('Error fetching fuzzy search list:', error);
    throw new Error('Failed to fetch fuzzy search list');
  }
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
        name: '新竹轉運站'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '生科館人社院'
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
        name: '新竹火車站(中正路)'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '新竹轉運站'
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
        name: '朝山'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '新竹火車站(中正路)'
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
        name: '香山天后宮'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '朝山'
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
        name: '青青草原'
      },
      location: {
        gps: '24.785061, 120.995061',
        name: '香山天后宮'
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