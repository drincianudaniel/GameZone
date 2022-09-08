import axios from "axios";
import { useEffect, useState } from "react";
import Reply from "./Reply";

function Replies(props) {

  const [replies, setReplies] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);

  useEffect(() => {
    getReplies();
  }, [page]);

  const getReplies = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_SERVERIP}/replies/comment/${
          props.commentId
        }/page/${page}/page-size/${4}`
      )
      .then((res) => {
        setReplies(res.data.data);
        setNumberOfPages(res.data.totalPages);
        console.log(res.data);
      });
  };

  return(
    <div>
    {replies.map((reply) => {
      return (
        <Reply key={reply.id} reply={reply} getReplies={getReplies} />
      );
    })}
  </div>
  )
}

export default Replies;
