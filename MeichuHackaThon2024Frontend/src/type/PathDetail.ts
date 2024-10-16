export type PathDetail = {
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