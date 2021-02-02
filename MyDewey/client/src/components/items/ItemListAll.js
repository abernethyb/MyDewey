import React, { useEffect, useContext, useState, useRef } from "react";
//import { ListGroup, ListGroupItem, Card, CardImg, CardBody, Button, CardTitle, CardSubtitle, Container } from "reactstrap";
import { useParams, useHistory, Link } from "react-router-dom";
import { Button, CardImg, Form, Table, FormGroup, Label, Input } from "reactstrap";
import { ItemContext } from "../../providers/ItemProvider";
import "./item.css"


const ItemList = () => {


    const { items, getAllItems } = useContext(ItemContext);

    const history = useHistory();


    useEffect(() => {

        getAllItems();
    }, []);

    if (!items) {
        return null;
    }

    return (
        <>
            <div className="container">
                <h2>Public Library</h2>
                <div className="row justify-content-left">


                    <hr />
                    {items.map((item) => (
                        <div className="itemList">

                            <div className="items" key={item.id}>
                                {/* < Link to={`item detai page TODO`}> */}
                                <p>Name: {item.name}</p>
                                <p>Name: {item.name}</p>
                                <p>Name: {item.name}</p>
                                <p>Owner: {item.ownerUserName}</p>
                                {/* <Image fluid rounded src={sample.image} alt={sample.name}></Image> */}

                                {/* <ReactImageFallback
                                width="100%"
                                src={`/api/image/${item.image}`}
                                fallbackImage={item.image}
                                alt={sample.name} /> */}
                                {/* </Link> */}

                            </div>
                        </div>
                    ))
                    }


                    <Table>

                        <thead>

                            <tr>
                                <th>Name</th>
                                <th>Owner</th>
                                <th>Category</th>
                                <th>Zip</th>
                            </tr>
                        </thead>

                        {items.map((item) => (
                            <tbody key={item.id}>
                                <tr>
                                    <th scope="row">

                                        {/* <Link to={``}> */}
                                        {item.name}
                                        {/* </Link> */}

                                    </th>
                                    <td>
                                        {item.ownerUserName}
                                    </td>

                                    <td>
                                        {item.categoryName}
                                    </td>
                                    <td>
                                        {item.ownerPostalCode}
                                    </td>

                                </tr>
                            </tbody>
                        ))}
                    </Table>
                </div>
            </div>
        </>
    );
};

export default ItemList;
