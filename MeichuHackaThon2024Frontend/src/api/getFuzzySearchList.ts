import axios from 'axios';
import type { FuzzyList } from './type';

export interface Payload {
  q: string;
  filter: 'all' | '觀光景點' | '美食' | '廁所';
}

/**
 * 取得模糊搜尋列表
 * @param {Payload} payload
 * @param {string} payload.q - 搜尋字串
 * @param {'all'|'觀光景點'|'美食'|'廁所'} [payload.filter='all'] - 篩選類型
 * @returns {Promise<FuzzyList>} 搜尋結果
 */
export async function getFuzzySearchList(payload: Payload): Promise<FuzzyList> {
  const { q, filter } = payload;
  try {
    const { data } = await axios.get<FuzzyList>('/getFuzzyList', {
      params: {
        q,
        filter
      }
    });
    return data;
  } catch (error) {
    console.error('Error fetching fuzzy search list:', error);
    throw new Error('Failed to fetch fuzzy search list');
  }
}