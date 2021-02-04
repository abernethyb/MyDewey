import React, { useEffect, useContext, useState, useRef } from "react";
//import { ListGroup, ListGroupItem, Card, CardImg, CardBody, Button, CardTitle, CardSubtitle, Container } from "reactstrap";
import { useParams, useHistory, Link } from "react-router-dom";
import { Button, CardImg, Form, Table, FormGroup, Label, Input } from "reactstrap";
import { ItemContext } from "../../providers/ItemProvider";


const UserItemList = () => {


    const { items, getUserItems } = useContext(ItemContext);

    const history = useHistory();


    useEffect(() => {

        getUserItems();
    }, []);

    if (!items) {
        return null;
    }

    return (
        <>

            <div className="itemList">
                <div className="itemListTop">
                    <h2>Your Library</h2>
                    <Link to="/your_library/new">
                        <Button >
                            Add Item
                    </Button>
                    </Link>
                </div>

                {items.map((item) => (

                    <div className="items" key={item.id}>
                        {/* < Link to={`item detai page TODO`}> */}
                        <p>Name: {item.name}</p>
                        <p>Category: {item.categoryName}</p>
                        {/* <Image fluid rounded src={sample.image} alt={sample.name}></Image> */}

                        {/* <ReactImageFallback
                                width="100%"
                                src={`/api/image/${item.image}`}
                                fallbackImage={item.image}
                                alt={sample.name} /> */}
                        {/* </Link> */}

                    </div>


                ))
                }
            </div>

        </>
    );
};

export default UserItemList;
