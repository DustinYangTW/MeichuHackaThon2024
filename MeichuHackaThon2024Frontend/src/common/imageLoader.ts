/**
 * Loads multiple images and resolves when all images are loaded
 * or rejects when one of the images fails to load.
 *
 * @param images - An array of image URLs to load.
 * @param onProgress - A callback function that is called when each image is loaded.
 * The callback function is called with two arguments: the number of images loaded
 * and the total number of images.
 * @param onError - A callback function that is called when an image fails to load.
 * The callback function is called with two arguments: the error and the URL of the
 * image that failed to load.
 *
 * @returns A promise that resolves when all images are loaded or rejects when
 * one of the images fails to load.
 */
export const imageLoader = (
  images: string[],
  onProgress?: (loaded: number, total: number) => void,
  onError?: (error: any, url: string) => void
): Promise<void> => {
  return new Promise<void>((resolve, reject) => {
    const totalImages = images.length;
    let loadedImages = 0;

    const promises = images.map(url => {
      return new Promise<void>((resolve, reject) => {
        const image = new Image();
        image.onload = () => {
          loadedImages++;
          if (onProgress) {
            onProgress(loadedImages, totalImages);
          }

          if (loadedImages === totalImages) {
            resolve();
          }
        };
        image.onerror = (error) => {
          onError && onError(error, url);
          reject(error);
        };
        image.src = url;
      });
    });

    Promise.all(promises)
      .then(() => {
        resolve();
      })
      .catch(error => {
        reject(error);
      });
  });
};