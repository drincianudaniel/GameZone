import * as React from "react";
import Dialog from "@mui/material/Dialog";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import { IconButton, Typography } from "@mui/material";
import CloseIcon from "@mui/icons-material/Close";
export default function FormDialog(props) {
  const handleClose = () => {
    props.setOpen(false);
  };

  const FormComponent = props.form;
  return (
    <div>
      <Dialog open={props.open} onClose={handleClose}>
        <DialogTitle
          sx={{
            display: "flex",
            justifyContent: "space-between",
            alignItems: "center",
          }}
        >
          <Typography variant="h5">Edit</Typography>
          <IconButton onClick={handleClose}>
            <CloseIcon />
          </IconButton>
        </DialogTitle>
        <DialogContent>
          <FormComponent {...props} handleClose={handleClose} />
        </DialogContent>
      </Dialog>
    </div>
  );
}
