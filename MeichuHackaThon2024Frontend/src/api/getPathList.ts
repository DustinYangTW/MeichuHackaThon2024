import axios from 'axios';
import type { Path } from '../api/type';

export interface Payload {
  /**
   * 目的地名稱
   */
  des: string;
  /**
   * 出發地名稱
   */
  loc: string;
}

export interface Response {
  pathList: Path[];
}

/**
 * 取得路徑列表
 * @param {Payload} payload
 * @param {string} payload.des - 目的地名稱
 * @param {string} payload.loc - 出發地名稱
 * @returns {Promise<Response>} 回傳路徑列表
 */
export async function getPathList(payload: Payload): Promise<Response> {
  const { des, loc } = payload;
  try {
    const { data } = await axios.post<Response>('/getPathList', {
      des, loc
    });
    return data;
  } catch (error) {
    console.error('Error fetching fuzzy search list:', error);
    throw new Error('Failed to fetch fuzzy search list');
  }
}