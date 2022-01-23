using _0_FrameWork.Application;
using _0_FramWork.Application;
using ShopManagement.Application.Contract.SliderDTO;
using ShopManagement.Domain.SliderAgg;
using System.Collections.Generic;

namespace ShopManagment.Application
{
    public class SliderApplication : ISliderApplication
    {
        private readonly ISlider _repository;
        private readonly IFileUploader _uploader;
        public SliderApplication(ISlider repository, IFileUploader uploader)
        {
            _repository = repository;
            _uploader = uploader;
        }
        public OperationResult Create(CreateSlider command)
        {
            OperationResult opreationResult = new OperationResult();
            string path = $"slider";
            var picproduct = _uploader.Upload(command.Picture, path);
            var entity = new Slider(picproduct, command.PictureAlt, command.PictureTitle, command.Heading, command.Title, command.Text, command.BtnText, command.Link);
            _repository.Create(entity);
            _repository.SaveChanges();
            return opreationResult.Success();
        }

        public OperationResult Edit(EditSlider command)
        {
            OperationResult opreationResult = new OperationResult();
            var entity = _repository.Get(command.Id);
            if (entity == null)
                return opreationResult.Failed(ApplicationMessage.RecordNotFound);
            string path = $"slider";
            var picproduct = _uploader.Upload(command.Picture, path);
            entity.Edit(picproduct, command.PictureAlt, command.PictureTitle, command.Heading, command.Title, command.Text, command.BtnText, command.Link);
            _repository.SaveChanges();
            return opreationResult.Success();
        }

        public EditSlider GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public List<SliderDTO> GetListSlider()
        {
            return _repository.GetAllSliderList();
        }

        public OperationResult Remove(long id)
        {
            OperationResult opreationResult = new OperationResult();
            var res = _repository.Get(id);
            res.IsRemove();
            _repository.SaveChanges();

            return opreationResult.Success();
        }

        public OperationResult Restore(long id)
        {
            OperationResult opreationResult = new OperationResult();
            var res = _repository.Get(id);
            res.IsRestore();
            _repository.SaveChanges();
            return opreationResult.Success();
        }
    }
}
