import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import Comment from "./Comment";
import PostCommentForm from "./Forms/PostCommentForm";
import GamePagination from "./GamePagination";

function Comments() {
  const [comments, setComments] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);
  const params = useParams();

  useEffect(() => {
    getComments();
  }, [page]);

  const getComments = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_SERVERIP}/comments/game/${
          params.id
        }/page/${page}/page-size/${4}`
      )
      .then((res) => {
        setComments(res.data.data);
        setNumberOfPages(res.data.totalCount);
        console.log(res.data);
      });
  };

  return (
    <div>
      {comments.map((comment) => {
        return (
          <Comment
            key={comment.id}
            comment={comment}
            getComments={getComments}
          />
        );
      })}
      <PostCommentForm id={params.id} />
      <GamePagination setPage={setPage} numberOfPages={numberOfPages} />
    </div>
  );
}

export default Comments;
