import { defineStore } from 'pinia'
import images from '../assets/homePg'
import { imageLoader } from '@/common/imageLoader';

interface ImageMap {
  [key: string]: string;
}

const homePagePgimagesList: ImageMap = images; // 添加類型注解

export const useImagesStore = defineStore({
  id: 'images',
  state: () => ({
    HomePageBg: [] as string[],
  }),
  getters: {

  },
  actions: {
    async preLoadImages() {
      Object.keys(homePagePgimagesList).forEach((key) => {
        this.HomePageBg.push(homePagePgimagesList[key] as string);
      })

      const loadedList: string[][] = [this.HomePageBg];

      loadedList.forEach((list) => {
        imageLoader(list);
      })
    }
  },
})
