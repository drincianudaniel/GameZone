import request from "./request";

export default class GameService{
    static getGamesPaginated(page){
        return request({
            url: `/games/page/${page}/page-size/${8}`,
            method: "GET"
        });
    }
}