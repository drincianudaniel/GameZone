import request from "./request";

export default class GenreService {
  static async getGenres() {
    return await request({
      url: "/genres",
      method: "GET",
    });
  }

  static async getGenresPaginated(page, searchString) {
    return await request({
      url: `/genres/page/${page}/page-size/${9}?searchString=${searchString}`,
      method: "GET",
    });
  }

  static async postGenre(data) {
    return await request({
      url: "/genres",
      method: "POST",
      data: data,
    });
  }

  static async deleteGenre(id) {
    return await request({
      url: `/genres/${id}`,
      method: "DELETE",
    });
  }

  static async updateGenre(id, data) {
    return await request({
      method: "PUT",
      url: `/genres/${id}`,
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
