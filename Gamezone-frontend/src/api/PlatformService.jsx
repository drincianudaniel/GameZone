import request from "./request";

export default class PlatformService {
  static async getPlatformsPaginated(page) {
    return await request({
      url: `/platforms/page/${page}/page-size/${10}`,
      method: "GET",
    });
  }

  static async deletePlatform(id) {
    return await request({
      url: `/platforms/${id}`,
      method: "DELETE",
    });
  }

}
