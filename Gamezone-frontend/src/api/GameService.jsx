import request from "./request";

export default class GameService {
  static async getGamesPaginated(page) {
    return await request({
      url: `/games/page/${page}/page-size/${8}`,
      method: "GET",
    });
  }

  static async getGamesWithUserFavorites(username, page) {
    return await request({
      url: `/games/user/${username}/page/${page}/page-size/${8}`,
      method: "GET",
    });
  }

  static async getHomePageGames(count, sortOrder) {
    return await request({
      url: `/games/number/${count}/sort-order/${sortOrder}`,
      method: "GET",
    });
  }

  static async getGame(id) {
    return await request({
      url: `/games/${id}`,
      method: "GET",
    });
  }

  static async deleteGame(id) {
    return await request({
      url: `/games/${id}`,
      method: "DELETE",
    });
  }

  static async postGame(data){
    return await request({
      url: "/games",
      method: "POST",
      data: data
    });
  }

  static async updateGameDetails(id, data) {
    return await request({
      url: `/games/${id}`,
      method: "PATCH",
      data: [{
        operationType: 0,
        path: "gameDetails",
        op: "replace",
        from: `${data.from}`,
        value: `${data.value}`,
      }],
      config: {
        headers: {
          Accept: "*/*",
          "Content-Type": "application/json-patch+json",
        },
      },
    });
  }
}
