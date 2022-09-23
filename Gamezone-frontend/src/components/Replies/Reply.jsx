import React from "react";
import Grid from "@mui/material/Grid";
import Avatar from "@mui/material/Avatar";
import Divider from "@mui/material/Divider";
import moment from "moment";
import axios from "axios";
import MoreMenu from "../Menus/MoreMenu";
import { convertUTCDateToLocalDate } from "../../utils/TimeConverting";

function Reply(props) {
  const handleDelete = async () => {
    await axios
      .delete(`${process.env.REACT_APP_SERVERIP}/replies/${props.reply.id}`)
      .then((response) => {
        props.getReplies();
      })
      .catch((err) => console.log(err));
  };

  return (
    <div style={{ padding: 14 }} className="App">
      <Grid container wrap="nowrap" spacing={2}>
        <Grid item>
          <Avatar alt="Remy Sharp" src={props.reply.userProfileImage} />
        </Grid>
        <Grid justifyContent="left" item xs zeroMinWidth>
          <h4 style={{ margin: 0, textAlign: "left" }}>
            {props.reply.userName}
          </h4>
          <p style={{ textAlign: "left" }}>{props.reply.content}</p>
          <p style={{ textAlign: "left", color: "gray" }}>
            {moment(
              convertUTCDateToLocalDate(new Date(props.reply.createdAt))
            ).fromNow()}
          </p>
        </Grid>
        <Grid>
          <MoreMenu handleDelete={handleDelete} />
        </Grid>
      </Grid>
      <Divider variant="fullWidth" style={{ margin: "30px 0" }} />
    </div>
  );
}

export default Reply;
