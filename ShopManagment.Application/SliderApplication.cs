using _0_FramWork.Application;
using ShopManagement.Application.Contract.SliderDTO;
using ShopManagement.Domain.SliderAgg;
using ShopManagement.Infrastrucer.Repository;
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
        public OpreationResult Create(CreateSlider command)
        {
            OpreationResult opreationResult = new OpreationResult();
            string path = $"slider";
           var picproduct= _uploader.Upload(command.Picture, path);
            var entity = new Slider(picproduct, command.PictureAlt, command.PictureTitle, command.Heading, command.Title, command.Text, command.BtnText, command.Link);
            _repository.Create(entity);
            _repository.SaveChanges();
            return opreationResult.Success();
        }

        public OpreationResult Edit(EditSlider command)
        {
            OpreationResult opreationResult = new OpreationResult();
            var entity = _repository.Get(command.Id);
            if (entity == null)
                return opreationResult.Faild(ApplicationMessage.RecordNotFound);
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

        public OpreationResult Remove(long id)
        {
            OpreationResult opreationResult = new OpreationResult();
            var res = _repository.Get(id);
            res.IsRemove();
            _repository.SaveChanges();

            return opreationResult.Success();
        }

        public OpreationResult Restore(long id)
        {
            OpreationResult opreationResult = new OpreationResult();
            var res = _repository.Get(id);
            res.IsRestore();
            _repository.SaveChanges();
            return opreationResult.Success();
        }
    }
}
