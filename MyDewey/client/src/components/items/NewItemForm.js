import React, { useState, useContext, useEffect, useRef } from "react";
import {
    Form,
    FormGroup,
    Card,
    CardBody,
    Label,
    Input,
    Button
} from "reactstrap";
import { useHistory, useParams } from "react-router-dom";
import { ItemContext } from "../../providers/ItemProvider";

const AddItem = () => {

    const { addItem } = useContext(ItemContext)
    //TODO: Image Upload
    //const { addImage } = useContext(ImageContext)
    const history = useHistory();
    const name = useRef(null)
    const author = useRef(null)
    const maker = useRef(null)
    const model = useRef(null)
    const yearMade = useRef(null)
    const notes = useRef(null)
    const externalId = useRef(null)


    //FOR IMAGE UPLOAD...eventually

    // const HandleImageUpload = (event) => {
    //     setImageUpload(event.target.files[0])
    //     console.log(event.target.files[0])
    //     console.log(imageUpload)
    // }

    const submit = () => {



        //FOR IMAGE UPLOAD...eventually

        // const formData = new FormData();
        // const fileName = `${new Date().getTime()}.${imageUpload.name.split('.').pop()}`
        // formData.append('imageUpload', imageUpload, fileName)

        // addImage(formData, fileName)




        const item = {
            //TODO: 
            //Make Category dropdown
            categoryId: 1,
            //ImageLocation: ...TODO
            name: name.current.value,
            author: author.current.value,
            maker: maker.current.value,
            model: model.current.value,
            yearMade: parseInt(yearMade.current.value),
            //image: fileName,
            notes: notes.current.value,
            externalId: externalId.current.value,
        };


        if (item.name !== "") {
            addItem(item).then((res) => {
                history.push(`/your_library`);
            });
        } else {
            window.alert("Please fill in Required fields")
        }



    };


    return (
        <div className="container pt-4">
            <div className="row justify-content-center">
                <Card className="col-sm-12 col-lg-6">
                    <CardBody>
                        <Form encType="multipart/form-data">


                            {/* <FormGroup>
                                <Label for="categoryId">Category</Label>
                                <select defaultValue="" name="categoryId" ref={categoryId} id="categoryId" className="form-control">
                                    <option value="0">Select a Category</option>
                                    {structures.map(e => (
                                        <option key={e.id} value={e.id}>
                                            {e.name}
                                        </option>
                                    ))}
                                </select>
                            </FormGroup> */}

                            <FormGroup>
                                <Label for="name">Item Name</Label>
                                <Input
                                    id="name"
                                    innerRef={name}
                                    maxLength="100"
                                />
                            </FormGroup>
                            <FormGroup>
                                <Label for="author">Author Name</Label>
                                <Input
                                    id="author"
                                    innerRef={author}
                                    maxLength="100"
                                />
                            </FormGroup>
                            <FormGroup>
                                <Label for="maker">Made or Printed By</Label>
                                <Input
                                    id="maker"
                                    innerRef={maker}
                                    maxLength="100"
                                />
                            </FormGroup>
                            <FormGroup>
                                <Label for="model">Item Model</Label>
                                <Input
                                    id="model"
                                    innerRef={model}
                                    maxLength="100"
                                />
                            </FormGroup>
                            <FormGroup>
                                <Label for="yearMade">Year Made</Label>
                                <Input
                                    id="yearMade"
                                    innerRef={yearMade}
                                    type="number"
                                />
                            </FormGroup>
                            <FormGroup>
                                <Label for="notes">Notes </Label>
                                <Input
                                    id="notes"
                                    innerRef={notes}
                                    maxLength="100"
                                />
                            </FormGroup>
                            <FormGroup>
                                <Label for="externalId">ISBN or Serial</Label>
                                <Input
                                    id="externalId"
                                    innerRef={externalId}
                                    maxLength="100"
                                />
                            </FormGroup>



                            {/* <div>
                                <hr />
                                {imageUpload ? <img width="50%" src={URL.createObjectURL(imageUpload)} alt="unable to show preview"></img> : <p>No image chosen</p>}
                            </div>
                            <FormGroup>
                                <Label for="image">Upload Image</Label>
                                <Input
                                    id="image"
                                    maxLength="3500"
                                    type="file"
                                    onChange={HandleImageUpload}
                                />
                            </FormGroup>
                            <hr /> */}




                        </Form>
                        <Button color="info" onClick={submit}>
                            SUBMIT
                        </Button>
                        <Button color="info"
                            onClick={() => { history.goBack() }}>
                            Cancel
                        </Button>
                    </CardBody>
                </Card>
            </div>
        </div>
    );
};

export default AddItem;