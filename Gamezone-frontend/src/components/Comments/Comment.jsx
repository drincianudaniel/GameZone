import React from "react";
import Grid from "@mui/material/Grid";
import Avatar from "@mui/material/Avatar";
import Divider from "@mui/material/Divider";
import moment from "moment";
import axios from "axios";
import MoreMenu from "../Menus/MoreMenu";
import RepliesDialog from "../Replies/RepliesDialog";

const imgLink =
  "https://images.pexels.com/photos/1681010/pexels-photo-1681010.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260";

function convertUTCDateToLocalDate(date) {
  var newDate = new Date(date.getTime() + date.getTimezoneOffset() * 60 * 1000);

  var offset = date.getTimezoneOffset() / 60;
  var hours = date.getHours();

  newDate.setHours(hours - offset);

  return newDate;
}

function Comment(props) {
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);

  const handleDelete = async () => {
    await axios
      .delete(`${process.env.REACT_APP_SERVERIP}/comments/${props.comment.id}`)
      .then((response) => {
        props.getComments();
      })
      .catch((err) => console.log(err));
  };

  return (
    <div style={{ padding: {lg: 14, xs: 1} }} className="App">
      <Grid container wrap="nowrap" spacing={2}>
        <Grid item>
          <Avatar alt="Remy Sharp" src={imgLink} />
        </Grid>
        <Grid justifyContent="left" item xs zeroMinWidth>
          <h4 style={{ margin: 0, textAlign: "left" }}>
            {props.comment.username}
          </h4>
          <p style={{ textAlign: "left" }}>{props.comment.content}</p>
          <p style={{ textAlign: "left", color: "gray" }}>
            {moment(
              convertUTCDateToLocalDate(new Date(props.comment.createdAt))
            ).fromNow()}
          </p>
          <RepliesDialog open={open} setOpen={setOpen} commentId={props.comment.id} comment={props.comment}/>
        </Grid>
        <Grid>
          <MoreMenu handleDelete={handleDelete}/>
        </Grid>
      </Grid>
      <Divider variant="fullWidth" style={{ margin: "30px 0" }} />
    </div>
  );
}

export default Comment;
