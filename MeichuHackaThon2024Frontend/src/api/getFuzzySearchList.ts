import axios from 'axios';
import type { FuzzyList } from './type';
import type { Response } from './transformResponse';
import { transformResponse } from './transformResponse';

export interface GetFuzzySearchListPayload {
  q: string;
  filter: 'all' | '觀光景點' | '美食' | '廁所';
}

/**
 * 取得模糊搜尋列表
 * @param {GetFuzzySearchListPayload} payload
 * @param {string} payload.q - 搜尋字串
 * @param {'all'|'觀光景點'|'美食'|'廁所'} [payload.filter='all'] - 篩選類型
 * @returns {Promise<FuzzyList>} 搜尋結果
 */
export async function getFuzzySearchList(payload: GetFuzzySearchListPayload): Promise<Response<FuzzyList>> {
  const { q, filter } = payload;
  try {
    // const response = await axios.get<FuzzyList>('/getFuzzyList', {
    //   params: {
    //     q,
    //     filter
    //   }
    // });

    const response: FuzzyList = await new Promise((resolve, reject) => {
      setTimeout(() => {
        resolve({
          list: mockData.filter((item) => item.includes(q))
        });
      }, 50);
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

const mockData = [
  '青青草原', '青草公園', '新竹體育館', '新竹舊派出所', '薰衣草森林', '新竹尖石', '小叮噹科學主題樂園', '十八尖山', '新竹市立動物園', '新竹都城煌廟'
]