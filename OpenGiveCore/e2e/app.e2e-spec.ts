import { OpenGiveCorePage } from './app.po';

describe('open-give-core App', () => {
  let page: OpenGiveCorePage;

  beforeEach(() => {
    page = new OpenGiveCorePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
