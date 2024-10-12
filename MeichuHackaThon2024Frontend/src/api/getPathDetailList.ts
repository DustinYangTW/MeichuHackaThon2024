import axios from 'axios';
import type { PathDetail } from './type';

export interface Payload {
  /**
   * 路徑編號
   */
  id: number;
}

export interface Response {
  pathDetailList: PathDetail[];
}

/**
 * 取得路徑詳細列表
 * @param {Payload} payload
 * @param {number} payload.id - 路徑編號
 * @returns {Promise<Response>} 回傳路徑詳細列表
 */
export async function getPathDetailList(payload: Payload): Promise<Response> {
  const { id } = payload;
  try {
    const { data } = await axios.post<Response>('/getPathDetailList', {
      id
    });
    return data;
  } catch (error) {
    console.error('Error fetching fuzzy search list:', error);
    throw new Error('Failed to fetch fuzzy search list');
  }
}