import request from "./request";

export default class GenreService {
  static async getGenresPaginated(page) {
    return await request({
      url: `/genres/page/${page}/page-size/${10}`,
      method: "GET",
    });
  }

  static async deleteGenre(id) {
    return await request({
      url: `/genres/${id}`,
      method: "DELETE",
    });
  }

}
