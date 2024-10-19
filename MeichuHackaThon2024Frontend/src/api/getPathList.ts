import axios from 'axios';
import type { Path } from '../api/type';
import type { Response } from './transformResponse';
import { transformResponse } from './transformResponse';

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
export async function getPathList(payload: GetPathListPayload): Promise<Response<Path[]>> {
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

const mockData: Path[] = [
  {
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
          gps: {
            lat: '120.99573887802406',
            lng: '24.78903620803964'
          },
          name: '國立陽明交通大學體育館'
        },
        location: {
          gps: {
            lat: '120.99042577195945',
            lng: '24.789935063671024'
          },
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
          gps: {
            lat: '120.97293793904349',
            lng: '24.80405034393874'
          },
          name: '新竹轉運站'
        },
        location: {
          gps: {
            lat: '120.99042577195945',
            lng: '24.789935063671024'
          },
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
          gps: {
            lat: '120.9713821394101',
            lng: '24.80348381742814'
          },
          name: '新竹火車站(中正路)'
        },
        location: {
          gps: {
            lat: '120.97293793904349',
            lng: '24.80405034393874'
          },
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
          gps: {
            lat: '120.997713',
            lng: '24.791641'
          },
          name: '朝山'
        },
        location: {
          gps: {
            lat: '120.9713821394101',
            lng: '24.80348381742814'
          },
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
          gps: {
            lat: '120.997713',
            lng: '24.791641'
          },
          name: '香山天后宮'
        },
        location: {
          gps: {
            lat: '120.995061',
            lng: '24.785061'
          },
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
          gps: {
            lat: '120.997713',
            lng: '24.791641'
          },
          name: '青青草原'
        },
        location: {
          gps: {
            lat: '120.995061',
            lng: '24.785061'
          },
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
  },
  {
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
          gps: {
            lat: '120.99573887802406',
            lng: '24.78903620803964'
          },
          name: '國立陽明交通大學體育館'
        },
        location: {
          gps: {
            lat: '120.99042577195945',
            lng: '24.789935063671024'
          },
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
          gps: {
            lat: '120.97293793904349',
            lng: '24.80405034393874'
          },
          name: '新竹轉運站'
        },
        location: {
          gps: {
            lat: '120.99042577195945',
            lng: '24.789935063671024'
          },
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
          gps: {
            lat: '120.9713821394101',
            lng: '24.80348381742814'
          },
          name: '新竹火車站(中正路)'
        },
        location: {
          gps: {
            lat: '120.97293793904349',
            lng: '24.80405034393874'
          },
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
          gps: {
            lat: '120.997713',
            lng: '24.791641'
          },
          name: '朝山'
        },
        location: {
          gps: {
            lat: '120.9713821394101',
            lng: '24.80348381742814'
          },
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
          gps: {
            lat: '120.997713',
            lng: '24.791641'
          },
          name: '香山天后宮'
        },
        location: {
          gps: {
            lat: '120.995061',
            lng: '24.785061'
          },
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
          gps: {
            lat: '120.997713',
            lng: '24.791641'
          },
          name: '青青草原'
        },
        location: {
          gps: {
            lat: '120.995061',
            lng: '24.785061'
          },
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
  }, {
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
          gps: {
            lat: '120.99573887802406',
            lng: '24.78903620803964'
          },
          name: '國立陽明交通大學體育館'
        },
        location: {
          gps: {
            lat: '120.99042577195945',
            lng: '24.789935063671024'
          },
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
          gps: {
            lat: '120.97293793904349',
            lng: '24.80405034393874'
          },
          name: '新竹轉運站'
        },
        location: {
          gps: {
            lat: '120.99042577195945',
            lng: '24.789935063671024'
          },
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
          gps: {
            lat: '120.9713821394101',
            lng: '24.80348381742814'
          },
          name: '新竹火車站(中正路)'
        },
        location: {
          gps: {
            lat: '120.97293793904349',
            lng: '24.80405034393874'
          },
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
          gps: {
            lat: '120.997713',
            lng: '24.791641'
          },
          name: '朝山'
        },
        location: {
          gps: {
            lat: '120.9713821394101',
            lng: '24.80348381742814'
          },
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
          gps: {
            lat: '120.997713',
            lng: '24.791641'
          },
          name: '香山天后宮'
        },
        location: {
          gps: {
            lat: '120.995061',
            lng: '24.785061'
          },
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
          gps: {
            lat: '120.997713',
            lng: '24.791641'
          },
          name: '青青草原'
        },
        location: {
          gps: {
            lat: '120.995061',
            lng: '24.785061'
          },
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
  }
];