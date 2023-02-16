import React, {useState } from 'react'

import { Form, Card, Button, InputGroup, Row, Col, Container, Alert } from 'react-bootstrap'
import { useFormik } from 'formik'

import axios from 'axios'

import * as yup from 'yup'

import './form.css'

const filterSchema = yup.object().shape({
    email: yup.string().email().required(),
    minRent: yup.number().notRequired(),
    maxRent: yup.number().notRequired(),
    apartment: yup.boolean().notRequired(),
    corridor: yup.boolean().notRequired(),
    minRooms: yup.number().notRequired(),
    maxRooms: yup.number().notRequired(),
    minFloor: yup.number().notRequired(),
    maxRentalPeriods: yup.number().notRequired(),
    novischPriority: yup.boolean().notRequired(),
    furnitureIncluded: yup.boolean().notRequired(),
    minSize: yup.number().notRequired(),
    maxSize: yup.number().notRequired(),
});

export default function ResetPasswordPage(){

    const handleSubmit = (data) => {
        console.log(data)
        axios.post('/notification', data, {withCredentials: true}).then(() => {
            alert('Notification Created')
        }).catch(() => {
            alert('Failed to create notification')
        })
    }

    const formik = useFormik({

        initialValues: {
            email: '',
            minRent: 0,
            maxRent: 100000,
            apartment: false,
            corridor: false,
            minRooms: 0,
            maxRooms: 10,
            minFloor: 0,
            maxRentalPeriods: 12,
            novischPriority: false,
            furnitureIncluded: false,
            minSize: 0,
            maxSize: 1000,
        },

        onSubmit: handleSubmit,
        validationSchema: filterSchema

    });

    return (
        <Container>
            <Row className="row">
                <Col md={6}>
                    <Card className="card">
                        <Card.Body>
                            <Card.Title className="title">Create Notification</Card.Title>
                            <Form>
                                <Row>
                                    <Col>
                                        <Form.Group className="form-group">
                                            <InputGroup>
                                                <Form.Control
                                                    className="form-input"
                                                    placeholder="Email"
                                                    type="string"
                                                    isInvalid={formik.errors.email && formik.touched.email}
                                                    name="email"
                                                    onChange={formik.handleChange}
                                                    onBlur={formik.handleBlur}
                                                    value={formik.values.email}
                                                />
                                                {formik.errors.email && formik.touched.email && 
                                                    <Form.Control.Feedback type="invalid">{formik.errors.email}</Form.Control.Feedback>
                                                }
                                            </InputGroup>
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col col={6}>
                                        <Form.Group className="form-group">
                                            <InputGroup>
                                                <Form.Control
                                                    className="form-input"
                                                    placeholder="Min Rent"
                                                    type="number"
                                                    name="minRent"
                                                    onChange={formik.handleChange}
                                                    onBlur={formik.handleBlur}
                                                    value={formik.values.minRent}
                                                />
                                            </InputGroup>
                                        </Form.Group>
                                    </Col>
                                    <Col col={6}>
                                        <Form.Group className="form-group">
                                            <InputGroup>
                                                <Form.Control
                                                    className="form-input"
                                                    placeholder="Max Rent"
                                                    type="number"
                                                    name="maxRent"
                                                    onChange={formik.handleChange}
                                                    onBlur={formik.handleBlur}
                                                    value={formik.values.maxRent}
                                                />
                                            </InputGroup>
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col col={6}>
                                        <Form.Group className="form-group">
                                            <InputGroup>
                                                <Form.Control
                                                    className="form-input"
                                                    placeholder="Min Rooms"
                                                    type="number"
                                                    name="minRooms"
                                                    onChange={formik.handleChange}
                                                    onBlur={formik.handleBlur}
                                                    value={formik.values.minRooms}
                                                />
                                            </InputGroup>
                                        </Form.Group>
                                    </Col>
                                    <Col col={6}>
                                        <Form.Group className="form-group">
                                            <InputGroup>
                                                <Form.Control
                                                    className="form-input"
                                                    placeholder="Max Rooms"
                                                    type="number"
                                                    name="maxRooms"
                                                    onChange={formik.handleChange}
                                                    onBlur={formik.handleBlur}
                                                    value={formik.values.maxRooms}
                                                />
                                            </InputGroup>
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col col={6}>
                                        <Form.Group className="form-group">
                                            <InputGroup>
                                                <Form.Control
                                                    className="form-input"
                                                    placeholder="Min Size"
                                                    type="number"
                                                    name="minSize"
                                                    onChange={formik.handleChange}
                                                    onBlur={formik.handleBlur}
                                                    value={formik.values.minSize}
                                                />
                                            </InputGroup>
                                        </Form.Group>
                                    </Col>
                                    <Col col={6}>
                                        <Form.Group className="form-group">
                                            <InputGroup>
                                                <Form.Control
                                                    className="form-input"
                                                    placeholder="Max Size"
                                                    type="number"
                                                    name="maxSize"
                                                    onChange={formik.handleChange}
                                                    onBlur={formik.handleBlur}
                                                    value={formik.values.maxSize}
                                                />
                                            </InputGroup>
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col>
                                        <Form.Group className="form-group">
                                            <InputGroup>
                                                <Form.Control
                                                    className="form-input"
                                                    placeholder="Min Floor"
                                                    type="number"
                                                    name="minFloor"
                                                    onChange={formik.handleChange}
                                                    onBlur={formik.handleBlur}
                                                    value={formik.values.minFloor}
                                                />
                                            </InputGroup>
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col>
                                        <Form.Group className="form-group">
                                            <InputGroup>
                                                <Form.Control
                                                    className="form-input"
                                                    placeholder="Max Rental Periods"
                                                    type="number"
                                                    name="maxRentalPeriods"
                                                    onChange={formik.handleChange}
                                                    onBlur={formik.handleBlur}
                                                    value={formik.values.maxRentalPeriods}
                                                />
                                            </InputGroup>
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col col={6}>
                                        <Form.Group className="form-group">
                                            <InputGroup>
                                                <Form.Check
                                                    label="Apartment"
                                                    className="form-input"
                                                    placeholder="Apartment"
                                                    type="checkbox"
                                                    name="apartment"
                                                    onChange={formik.handleChange}
                                                    onBlur={formik.handleBlur}
                                                    value={formik.values.apartment}
                                                />
                                            </InputGroup>
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col col={6}>
                                        <Form.Group className="form-group">
                                            <InputGroup>
                                                <Form.Check
                                                    label="Corridor"
                                                    className="form-input"
                                                    placeholder="Corridor"
                                                    type="checkbox"
                                                    name="corridor"
                                                    onChange={formik.handleChange}
                                                    onBlur={formik.handleBlur}
                                                    value={formik.values.corridor}
                                                />
                                            </InputGroup>
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col col={6}>
                                        <Form.Group className="form-group">
                                            <InputGroup>
                                                <Form.Check
                                                    label="Noisch Priority"
                                                    className="form-input"
                                                    type="checkbox"
                                                    name="novischPriority"
                                                    onChange={formik.handleChange}
                                                    onBlur={formik.handleBlur}
                                                    value={formik.values.novischPriority}
                                                />
                                            </InputGroup>
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col col={6}>
                                        <Form.Group className="form-group">
                                            <InputGroup>
                                                <Form.Check
                                                    label="Furniture Included"
                                                    className="form-input"
                                                    type="checkbox"
                                                    name="furnitureIncluded"
                                                    onChange={formik.handleChange}
                                                    onBlur={formik.handleBlur}
                                                    value={formik.values.furnitureIncluded}
                                                />
                                            </InputGroup>
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col>
                                        <Button variant="outline-success" className="reset-button" onClick={formik.handleSubmit}>Create</Button>
                                    </Col>
                                </Row>
                            </Form>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        </Container>
    )
}