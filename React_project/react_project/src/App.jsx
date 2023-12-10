import React, { useState } from 'react';
import { Button, Dialog, DialogActions, DialogContent, DialogTitle, List, ListItem, TextField } from '@mui/material';
import grapesjs, { Editor } from 'grapesjs';
import GjsEditor, { Canvas } from 'grapesjs';
import './styles.css';

const App = () => {
        const [open, setOpen] = useState(false);
        const [arrayIndex, setArrayIndex] = useState(0);
        const [arrayList, setArrayList] = useState([]);
        const [username, setUsername] = useState('Author Name');
        const [text, setText] = useState('What\'s on your mind?');
        const [image, setImage] = useState('path-to-your-image.jpg');


    const addItem = () => {
        setArrayList([...arrayList, `User ${arrayList.length + 1}`]);
    };

    const removeItem = () => {
        if (arrayList.length > 0) {
            setArrayList(arrayList.slice(0, -1));
        }
    };

    const moveDown = () => {
        if (arrayIndex < arrayList.length - 1) {
            setArrayIndex(arrayIndex + 1);
        } else {
            setArrayIndex(0);
        }
    };

    const moveUp = () => {
        if (arrayIndex > 0) {
            setArrayIndex(arrayIndex - 1);
        } else {
            setArrayIndex(arrayList.length - 1);
        }
    };

    const msgUser = () => {
        setOpen(true);
    };

    const editItem = () => {
        const newArray = [...arrayList];
        newArray[arrayIndex] = username;
        setArrayList(newArray);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const changeUser = () => {
        setUsername('New Username');
        setText('New Text');
    };

    const changeImg = () => {
        const input = document.createElement('input');
        input.type = 'file';
        input.accept = 'image/*';
        input.click();
        input.onchange = (e) => {
            const file = e.target.files[0];
            const reader = new FileReader();
            reader.onload = (e) => {
                setImage(e.target.result);
            };
            reader.readAsDataURL(file);
        };
    };

    return (
        <div>
            <div className="listIndex">
            <List>
                {arrayList.map((item, index) => (
                    <ListItem key={index} selected={arrayIndex === index}>
                        {item}
                    </ListItem>
                ))}
                </List>
            </div>
            <div className="fixed-container">
                <Button onClick={addItem}>Add</Button>
                <Button onClick={removeItem}>Remove</Button>
                <Button onClick={moveDown}>Down</Button>
                <Button onClick={moveUp}>Up</Button>
                <Button onClick={msgUser}>Message</Button>
                </div>
            <Dialog onClose={handleClose} open={open}>
                <DialogTitle>Change Username and Text</DialogTitle>
                <br />
                <DialogContent>
                    <Button onClick={editItem}>Edit from Friend list</Button>
                    <Button onClick={changeImg}>Change User Photo</Button><br/>



                    <TextField label="Username" value={username} onChange={(e) => setUsername(e.target.value)} />
                    <TextField label="Text" value={text} onChange={(e) => setText(e.target.value)} />
                    <br /><br /> <br />
                    <div class="fb-post">
                        <div class="post-image">
                            <img src={image} alt="Profile Picture" />
                            
                        </div>
                        <div class="post-content">
                            <h4 class="post-author">{username}
                            </h4>
                            <p class="post-text">{text}
                            </p>
                        </div>
                    </div>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Close</Button>
                </DialogActions>
            </Dialog>
        </div>
    );
}
export default App;
