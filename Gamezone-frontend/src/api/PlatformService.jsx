import request from "./request";

export default class PlatformService {
  static async getPlatforms() {
    return await request({
      url: "/platforms",
      method: "GET",
    });
  }

  static async getPlatformsPaginated(page, searchString) {
    return await request({
      url: `/platforms/page/${page}/page-size/${9}?searchString=${searchString}`,
      method: "GET",
    });
  }

  static async postPlatform(data) {
    return await request({
      url: "/platforms",
      method: "POST",
      data: data,
    });
  }

  static async deletePlatform(id) {
    return await request({
      url: `/platforms/${id}`,
      method: "DELETE",
    });
  }

  static async updatePlatform(id, data) {
    return await request({
      method: "PUT",
      url: `/platforms/${id}`,
      data: data,
      config: {
        headers: {
          Accept: "*/*",
          "Content-Type": "application/json-patch+json",
        },
      },
    });
  }
}
