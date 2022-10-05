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

  static async getGames() {
    return await request({
      url: `/games`,
      method: "GET",
    });
  }

  static async deleteGame(id) {
    return await request({
      url: `/games/${id}`,
      method: "DELETE",
    });
  }

  static async postGame(data) {
    return await request({
      url: "/games",
      method: "POST",
      data: data,
    });
  }

  static async updateGameDetails(id, data) {
    return await request({
      url: `/games/${id}`,
      method: "PATCH",
      data: [
        {
          operationType: 0,
          path: "gameDetails",
          op: "replace",
          from: `${data.from}`,
          value: `${data.value}`,
        },
      ],
      config: {
        headers: {
          Accept: "*/*",
          "Content-Type": "application/json-patch+json",
        },
      },
    });
  }

  static async updateGameName(id, data) {
    return await request({
      url: `/games/${id}`,
      method: "PATCH",
      data: [
        {
          operationType: 0,
          path: "name",
          op: "replace",
          from: `${data.from}`,
          value: `${data.value}`,
        },
      ],
      config: {
        headers: {
          Accept: "*/*",
          "Content-Type": "application/json-patch+json",
        },
      },
    });
  }

  static async updateGameDate(id, data) {
    return await request({
      url: `/games/${id}`,
      method: "PATCH",
      data: [
        {
          operationType: 0,
          path: "releaseDate",
          op: "replace",
          from: `${data.from}`,
          value: `${data.value}`,
        },
      ],
      config: {
        headers: {
          Accept: "*/*",
          "Content-Type": "application/json-patch+json",
        },
      },
    });
  }

  static async AddGenre(gameid, genreid) {
    return await request({
      url: `/games/game/${gameid}/genre/${genreid}`,
      method: "POST",
    });
  }

  static async AddDeveloper(gameid, developerid) {
    return await request({
      url: `/games/game/${gameid}/developer/${developerid}`,
      method: "POST",
    });
  }

  static async AddPlatform(gameid, platformid) {
    return await request({
      url: `/games/game/${gameid}/platform/${platformid}`,
      method: "POST",
    });
  }

  static async RemoveGenre(gameid, genreid) {
    return await request({
      url: `/games/game/${gameid}/genre/${genreid}`,
      method: "DELETE",
    });
  }

  static async RemovePlatform(gameid, platformid) {
    return await request({
      url: `/games/game/${gameid}/platform/${platformid}`,
      method: "DELETE",
    });
  }

  static async RemoveDeveloper(gameid, developerid) {
    return await request({
      url: `/games/game/${gameid}/developer/${developerid}`,
      method: "DELETE",
    });
  }
}
