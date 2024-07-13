import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';

function App() {
  const [data, setData] = useState([]);
  const [modal, setModal] = useState(false);
  const [selectedItem, setSelectedItem] = useState(null);

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const response = await axios.get('http://localhost:5114/api/Gestors');
      setData(response.data);
    } catch (error) {
      console.error('Error fetching data:', error);
    }
  };

  const toggleModal = () => {
    setModal(!modal);
  };

  const handleEdit = (item) => {
    setSelectedItem(item);
    toggleModal();
  };
  const handleNew = (item) => {
    setSelectedItem({
      name:'',
      release:'',
      dev_company:''
    });
    toggleModal();
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`http://localhost:5114/api/Gestors/${id}`);
      fetchData();
    } catch (error) {
      console.error('Error deleting item:', error);
    }
  };

  const handleModalSave = async () => {
    try {
      if(selectedItem.id){
      await axios.put(`http://localhost:5114/api/Gestors/${selectedItem.id}`,selectedItem);
      fetchData()
    }else{
      await axios.post(`http://localhost:5114/api/Gestors/`,selectedItem);
      fetchData()
    }
    } catch (error) {
      console.error('Error deleting item:', error);
    }
    toggleModal();
  };

  return (
    <div className="App">
      <h1 className="mt-4">Gestores</h1>
      <button className="btn btn-info mr-2" onClick={() => handleNew()}>
        New
      </button>
      <table className="table mt-4">
        <thead className="thead-dark">
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Release</th>
            <th>Developer Company</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {data.map((item) => (
            <tr key={item.id}>
              <td>{item.id}</td>
              <td>{item.name}</td>
              <td>{item.release}</td>
              <td>{item.dev_company}</td>
              <td>
                <button className="btn btn-info mr-2" onClick={() => handleEdit(item)}>
                  Edit
                </button>
                <button className="btn btn-danger" onClick={() => handleDelete(item.id)}>
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Modal */}
      <Modal isOpen={modal} toggle={toggleModal}>
        <ModalHeader toggle={toggleModal}>Gestor</ModalHeader>
        <ModalBody>
          <form>
            <div className="form-group">
              <label htmlFor="name">Name</label>
              <input
                type="text"
                className="form-control"
                id="name"
                value={selectedItem ? selectedItem.name : ''}
                onChange={(e) =>
                  setSelectedItem({ ...selectedItem, name: e.target.value })
                }
              />
            </div>
            <div className="form-group">
              <label htmlFor="release">Release</label>
              <input
                type="text"
                className="form-control"
                id="release"
                value={selectedItem ? selectedItem.release : ''}
                onChange={(e) =>
                  setSelectedItem({ ...selectedItem, release: e.target.value })
                }
              />
            </div>
            <div className="form-group">
              <label htmlFor="dev_company">Developer Company</label>
              <input
                type="text"
                className="form-control"
                id="dev_company"
                value={selectedItem ? selectedItem.dev_company : ''}
                onChange={(e) =>
                  setSelectedItem({ ...selectedItem, dev_company: e.target.value })
                }
              />
            </div>
          </form>
        </ModalBody>
        <ModalFooter>
          <button className="btn btn-primary" onClick={handleModalSave}>
            Save Changes
          </button>
          <button className="btn btn-secondary" onClick={toggleModal}>
            Cancel
          </button>
        </ModalFooter>
      </Modal>
    </div>
  );
}

export default App;
