import request from "./request";

export default class GameService{
    
    static async getGamesPaginated(page){
        return await request({
            url: `/games/page/${page}/page-size/${8}`,
            method: "GET"
        });
    }

    static async getHomePageGames(count, sortOrder){
        return await request({
            url: `/games/number/${count}/sort-order/${sortOrder}`,
            method: "GET"
        })
    }

    static async getGame(id){
        return await request({
            url: `/games/${id}`,
            method: "GET"
        })
    }
}