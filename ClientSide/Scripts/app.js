const API_HOST = "http://localhost:59901";
class App extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            rooms: [],
            categories: [],
            types: [],
            roomCrud: {
                category: '',
                size: '',
                type: ''
            }
        }

        this.fetchRoomDetails = this.fetchRoomDetails.bind(this)
        this.fetchCategories = this.fetchCategories.bind(this)
        this.fetchTypes = this.fetchTypes.bind(this)
        this.getCategoryById = this.getCategoryById.bind(this)
        this.getTypeById = this.getTypeById.bind(this)
        this.handleDelete = this.handleDelete.bind(this)
        this.handleCreate = this.handleCreate.bind(this)
        this.handleUpdate = this.handleUpdate.bind(this)
    }

    fetchRoomDetails(rooms) {
        this.setState({ rooms: rooms });
    }

    fetchCategories(categories) {
        this.setState({ categories: categories });
    }

    fetchTypes(types) {
        this.setState({ types: types });
    }

    getCategoryById(id) {
        console.log(id)
        let index = this.state.categories.findIndex(category => category.Id == id)
        return this.state.categories[id].CategoryName
    }

    getTypeById(id) {
        let index = this.state.types.findIndex(type => type.Id == id)
        return this.state.types[id].TypeName
    }

    handleDelete(room) {
        let rooms = this.state.rooms
        let id = room.id

        fetch(API_HOST + '/api/rooms/' + id, {
            method: 'delete'
        })
            .then(res => {
                return res.json()
            })
            .then(room => {
                rooms = rooms.filter(r => r.id != id)
                this.setState({ rooms })
            })
            .catch(err => console.log);
    }

    handleCreate(room) {
        const { size, category, type } = room
        const categories = this.state.categories
        const types = this.state.types

        //    .reduce(category => category.CategoryName == category)
        //const typeId = this.state.types
        //    .reduce(type => type.TypeName == type)
        let categoryId
        let typeId

        for (let i = 0; i < categories.length; i++) {
            if (categories[i].categoryName == category) {
                categoryId = categories[i].id
            }
        }

        for (let i = 0; i < types.length; i++) {
            if (types[i].typeName == type) {
                typeId = types[i].id
            }
        }

        fetch(API_HOST + '/api/rooms/', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                roomSize: size,
                roomCategoryId: categoryId,
                roomTypeId: typeId
            })
        }).then(res => res.json()).then(room => {
            let rooms = this.state.rooms
            rooms.push(room)

            this.setState({ rooms })
        })
    }

    handleUpdate() { }

    render() {
        return (
            <div>
                <Rooms
                    rooms={this.state.rooms}
                    types={this.state.types}
                    categories={this.state.categories}
                    fetchRoomDetails={this.fetchRoomDetails}
                    fetchCategories={this.fetchCategories}
                    fetchTypes={this.fetchTypes}
                    getCategoryById={this.getCategoryById}
                    getTypeById={this.getTypeById}
                    handleDelete={this.handleDelete}
                    handleCreate={this.handleCreate}
                    roomCrud={this.state.roomCrud}
                />
            </div>
        )
    }
}

class Rooms extends React.Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        fetch(API_HOST + '/api/rooms/')
            .then(res => {
                //console.log(res);
                return res.json();
            })
            .then(rooms => {
                return this.props.fetchRoomDetails(rooms)
            })
            .catch(err => {
                console.log(err);
            })

        fetch(API_HOST + '/api/roomcategories/')
            .then(res => {
                //console.log(res);
                return res.json();
            })
            .then(categories => {
                return this.props.fetchCategories(categories)
            })

        fetch(API_HOST + '/api/roomtypes/')
            .then(res => {
                //console.log(res);
                return res.json();
            })
            .then(types => {
                return this.props.fetchTypes(types)
            })
    }

    render() {
        return (
            <table className="table">
                <thead>
                    <tr>
                        <th>Size</th>
                        <th>Category</th>
                        <th>Type</th>
                    </tr>
                </thead>
                <tbody>
                    <RoomForm
                        categories={this.props.categories}
                        types={this.props.types}
                        roomCrud={this.props.roomCrud}
                        handleCreate={this.props.handleCreate}
                    />
                    {this.props.rooms.map(room =>
                        <Room
                            key={room.id}
                            room={room}
                            categories={this.props.categories}
                            types={this.props.types}
                            getCategoryById={this.props.getCategoryById}
                            getTypeById={this.props.getTypeById}
                            handleDelete={this.props.handleDelete}
                            roomCrud={this.props.roomCrud}
                        />
                    )}
                </tbody>
            </table>
        )
    }
}

class RoomForm extends React.Component {
    constructor(props) {
        super(props)

        this.state = {
            size: '',
            category: 'Lux',
            type: 'Double with two beds'
        }

        this.handleChange = this.handleChange.bind(this)
        this.handleAdd = this.handleAdd.bind(this)
        this.handleDropdownChange = this.handleDropdownChange.bind(this)
    }

    handleChange(e) {
        const value = e.target.value
        this.setState({ size: value })
    }

    handleDropdownChange(e) {
        const value = e.target.value
        const name = e.target.name

        if (name == "category") {
            this.setState({ category: value })
        } else if (name == "type") {
            this.setState({ type: value })
        }
    }

    handleAdd(e) {
        e.preventDefault();
        const { size, category, type } = this.state

        const room = { size, category, type }
        this.props.handleCreate(room)
    }

    render() {
        return (
            <tr>
                <td>
                    <input type="text"
                        name="size"
                        className="form-control"
                        placeholder="Size"
                        defaultValue={this.state.size}
                        onChange={this.handleChange}
                    />
                </td>
                <td>
                    <select className="form-control"
                        name="category"
                        value={this.state.category}
                        onChange={this.handleDropdownChange}
                    >
                        {this.props.categories.map(category =>
                            <option key={category.id} value={category.categoryName}>
                                {category.categoryName}
                            </option>
                        )}
                    </select>
                </td>
                <td>
                    <select className="form-control"
                        name="type"
                        value={this.state.type}
                        onChange={this.handleDropdownChange}
                    >
                        {this.props.types.map(type =>
                            <option key={type.id} value={type.typeName}>
                                {type.typeName}
                            </option>
                        )}
                    </select>
                </td>
                <td>
                    <a href="" onClick={this.handleAdd}>Create</a>
                </td>
                <td></td>
            </tr>
        )
    }
}

class Room extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            id: -1,
            category: '',
            categoryId: -1,
            type: '',
            typeId: -1,
            size: ''
        }

        this.handleDelete = this.handleDelete.bind(this)
    }

    static getDerivedStateFromProps(props) {
        let category
        let type

        if (props.room.roomCategoryId == 1) {
            category = "Lux"
        } else if (props.room.roomCategoryId == 2) {
            category = "Semi lux"
        } else if (props.room.roomCategoryId == 3) {
            category = "Standard"
        }

        if (props.room.roomTypeId == 1) {
            type = "Double with two beds"
        } else if (props.room.roomTypeId == 2) {
            type = "Double with one bed"
        } else if (props.room.roomTypeId == 3) {
            type = "Single bed"
        }

        return {
            id: props.room.id,
            category: category,
            categoryId: props.room.roomCategoryId,
            type: type,
            typeId: props.room.roomTypeId,
            size: props.room.roomSize
        }
    }

    handleDelete(e) {
        e.preventDefault();

        const room = this.state
        this.props.handleDelete(room);
    }

    render() {
        return (
            <tr>
                <td>{this.state.size}</td>
                <td>{this.state.category}</td>
                <td>{this.state.type}</td>
                <td>
                    <a href="" onClick={this.handleEdit}>Edit</a>
                </td>
                <td>
                    <a href="" onClick={this.handleDelete}>Delete</a>
                </td>
            </tr>
        )
    }
}

ReactDOM.render(<App />, document.getElementById("app"))