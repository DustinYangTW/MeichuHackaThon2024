export interface FuzzyList {
  /**
   * 查詢關鍵字 列表
   */
  list: string[];
}

export type vehicle = "公車" | "Bike" | "步行" | "共乘";

export interface Path {
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
  arrivalTime: string;
  /**
   * 交通工具種類以及%數
   */
  transportComp: Record<vehicle, number>;
  /**
   * 擁擠程度
   */
  crowding: number;
  /**
   * 子路徑選項
   */
  path_details: PathDetail[];
}

export interface PathDetail {
  /**
   * 目的地名稱
   * @example ‘青青草原’ | ‘新竹體育館’
   */
  destination: {
    gps: {
      lat: string;
      lng: string;
    };
    name: string;
  };
  /**
   * 本地位置名稱
   * @example ‘本地’ | '陽明交大'
   */
  location: {
    gps: {
      lat: string;
      lng: string;
    };
    name: string;
  };
  /**
   * 耗時
   * @example "1h 30m"
   */
  costTime: string;
  /**
   * 到達時間
   * @example "11:30"
   */
  arrivalTime: string;
  /**
   * 交通工具
   */
  transport: {
    type: vehicle;
    /**
     * 公車 Ubike 會有車號或是站號
     */
    remark: string;
  };
  /**
   * 擁擠程度
   */
  crowding: number;
}
